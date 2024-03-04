namespace NASA.Mobile.Models
{
    public class MarsPhotoResponse
    {
        public List<Photo> Photos { get; set; }
    }
    public class Photo
    {
        public int Id { get; set; }
        public int Sol { get; set; }
        public Camera Camera { get; set; }
        public string Img_Src { get; set; }
        public string Earth_Date { get; set; }
        public Rover Rover { get; set; }
    }
}
