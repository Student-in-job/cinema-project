namespace OnlineCinemaProject.Models.ViewModels
{
    public class VideoGridModel:video
    {
        public int Country { get; set; }
        public int Genre { get; set; }
        public int Actor { get; set; }
    }
}