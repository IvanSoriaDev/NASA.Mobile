namespace NASA.Mobile.Models
{
    public struct Rover
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Landing_Date { get; set; }
        public string Launch_Date { get; set; }
        public string Status { get; set; }
        public int Max_Sol { get; set; }
        public string Max_Date { get; set; }
        public int Total_Photos { get; set; }
        public List<Camera> Cameras { get; set; }

    }
}
