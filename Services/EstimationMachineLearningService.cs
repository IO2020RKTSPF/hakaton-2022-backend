using AutoMapper;
using BitadAPI.Repositories;
using hakaton_2022_backend.Entities;
using hakaton_2022_backend.Models;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace hakaton_2022_backend.Services;

public class EstimationMachineLearningService : IEstimationMachineLearningService
{
    private readonly IEstimationRepository _estimationRepository;
    private readonly IMapper _mapper;

    public EstimationMachineLearningService(IEstimationRepository estimationRepository, IMapper mapper)
    {
        _estimationRepository = estimationRepository;
        _mapper = mapper;
    }
    public async Task<int> Calculate(EstimationModel estimationModel)
    {
        //Create ML Context with seed for repeteable/deterministic results
        MLContext mlContext = new MLContext();
        
        // STEP 1: Common data loading configuration
        var estimations = (await _estimationRepository.GetAllEstimations()).Take(5);
        var estimationModels1 = _mapper.Map<IEnumerable<EstimationModel>>(estimations);
        IDataView baseTrainingDataView = mlContext.Data.LoadFromEnumerable<EstimationModel>(estimationModels1);
        IDataView testDataView = mlContext.Data.LoadFromEnumerable<EstimationModel>(_mapper.Map<IEnumerable<EstimationModel>>((await _estimationRepository.GetAllEstimations()).Skip(5).Take(2)));

        //Sample code of removing extreme data like "outliers" for FareAmounts higher than $150 and lower than $1 which can be error-data 
        var cnt = baseTrainingDataView.GetColumn<float>(nameof(EstimationModel.UserResult)).Count();
        IDataView trainingDataView = mlContext.Data.FilterRowsByColumn(baseTrainingDataView, nameof(EstimationModel.UserResult), lowerBound: 60, upperBound: 2280);
        var cnt2 = trainingDataView.GetColumn<float>(nameof(EstimationModel.UserResult)).Count();

        // STEP 2: Common data process configuration with pipeline data transformations
        var dataProcessPipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(EstimationModel.UserResult))
                            .Append(mlContext.Transforms.NormalizeMeanVariance(outputColumnName: nameof(EstimationModel.CodeFamiliarity)))
                            .Append(mlContext.Transforms.NormalizeMeanVariance(outputColumnName: nameof(EstimationModel.ExperienceLevel)))
                            .Append(mlContext.Transforms.NormalizeMeanVariance(outputColumnName: nameof(EstimationModel.ProjectScale)))
                            .Append(mlContext.Transforms.NormalizeMeanVariance(outputColumnName: nameof(EstimationModel.TaskKnowledge)))
                            .Append(mlContext.Transforms.NormalizeMeanVariance(outputColumnName: nameof(EstimationModel.DesiredCodeQuality)))
                            .Append(mlContext.Transforms.NormalizeMeanVariance(outputColumnName: nameof(EstimationModel.LinesOfCode)))
                            .Append(mlContext.Transforms.Concatenate("Features", nameof(EstimationModel.CodeFamiliarity)
                            , nameof(EstimationModel.ExperienceLevel), nameof(EstimationModel.ProjectScale), nameof(EstimationModel.TaskKnowledge), 
                            nameof(EstimationModel.DesiredCodeQuality), nameof(EstimationModel.LinesOfCode)));


        // STEP 3: Set the training algorithm, then create and config the modelBuilder - Selected Trainer (SDCA Regression algorithm)                            
        var trainer = mlContext.Regression.Trainers.Sdca(labelColumnName: "Label", featureColumnName: "Features");
        var trainingPipeline = dataProcessPipeline.Append(trainer);
        
        var trainedModel = trainingPipeline.Fit(trainingDataView);
        

        IDataView predictions = trainedModel.Transform(testDataView);
        var metrics = mlContext.Regression.Evaluate(predictions, labelColumnName: "Label", scoreColumnName: "Score");
        Console.WriteLine(trainer.ToString(), metrics);
        //mlContext.Model.Save(trainedModel, trainingDataView.Schema, "/Users/tsteblik/Source/GitRepos/hackaton/hakaton-2022-backend/model.zip");


        estimationModel.UserResult = 0;
        
        var predEngine = mlContext.Model.CreatePredictionEngine<EstimationModel, EstimationModelPrediction>(trainedModel);

//Score
        var resultprediction = predEngine.Predict(estimationModel);
        return (int)resultprediction.UserResult;
    }
}