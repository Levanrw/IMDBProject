using FluentValidation;
using IMDB.Models.Eenums;

namespace IMDB.Models.RequestModels
{
    /// <summary>
/// Search movie model
/// </summary>
    public class SearchMovieModel
    {
        /// <summary>
    /// Movie Name
    /// </summary>
        public string MovieName { get; set; }
        /// <summary>
        /// Movie language
        /// </summary>
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
