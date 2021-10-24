using FluentValidation;
using IMDB.Models.Eenums;

namespace IMDB.Models.RequestModels
{
   public class SearchMovieModel
    {       
        public string MovieName { get; set; }
        public Language Lang { get; set; }

    }

    public class SearchMovieModelValidator : AbstractValidator<SearchMovieModel>
    {
        public SearchMovieModelValidator()
        {
            RuleFor(p => p.MovieName.Trim()).MinimumLength(3);
            RuleFor(p => p.MovieName).NotNull();
        }
    }
}
