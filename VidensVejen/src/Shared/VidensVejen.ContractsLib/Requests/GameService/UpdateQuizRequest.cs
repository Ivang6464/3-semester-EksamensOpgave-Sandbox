namespace VidensVejen.ContractsLib.Requests.GameService;

/// <summary>
/// 
/// </summary>
/// <param name="Title"></param>
/// <param name="ExhibitionId"></param>
/// <param name="QuizLayout"></param>
/// <param name="Questions"></param>
/// <example>
/// {
///     "title": "Affaldshierakiet",
///     "exhibitionId": "123e4567-e89b-12d3-a456-426614174000",
///     "quizLayout": "Vertikalt",
///     "questions": [
///         {
///             "id": "123e4567-e89b-12d3-a456-426614174000",
///             "text": "Hvad skal dette sorteres som?",
///             "imageKey": "img-1",
///             "choices": [
///                 {
///                     "id": "123e4567-e89b-12d3-a456-426614174000",
///                     "text": "Plastik",
///                     "correctAnswer": true,
///                     "imageKey": "img-1"
///                 }
///             ]
///         }
///     ]
/// }
/// </example>
public record UpdateQuizRequest(
    string Title,
    Guid ExhibitionId,
    string QuizLayout,
    List<UpdateQuestionRequest> Questions
    );
