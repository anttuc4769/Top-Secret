namespace Hydra.Models
{
    public class EnumListModel : BaseModel
    {
        public List<EnumModel> Types { get; set; }
    }

    public class EnumModel : BaseModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
    }
}
