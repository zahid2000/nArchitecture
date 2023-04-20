namespace Application.Features.Models.Models;

public class ModelListModel:BasePageableModel
{
    public IList<ModelListDto> Items{ get; set; }
}
