using FluentValidation;

namespace IMDB.Models.RequestModels
{
   public class WatchListRequest
    {
        /// <summary>
        /// ფილმი
        /// </summary>
        public string MovieId { get; set; }
       
    }
    public class WatchListRequestValidator : AbstractValidator<WatchListRequest>
    {
        public WatchListRequestValidator()
        {
            RuleFor(p => p.MovieId).NotNull().WithMessage("Movie is not selected!");
        }
    }
}
