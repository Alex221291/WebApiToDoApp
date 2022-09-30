namespace WebApiToDoApp.ViewModels
{
    public class UpdateToDoViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Discription { get; set; }
        public bool IsCompleted { get; set; }
    }
}
