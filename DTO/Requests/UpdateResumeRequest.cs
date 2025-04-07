namespace ResumeFinder.DTO.Requests
{
    public class UpdateResumeRequest
    {
        public long Id { get; set; }

        public long WorkerId { get; set; }

        public string Name { get; set; }
    }
}
