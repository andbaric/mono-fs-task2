namespace Project.Model.Common.VehicleModelResource
{
    public interface IVehicleModelsFilter
    {
        string Name { get; set; }
        string Abrv { get; set; }

        string MakeName { get; set; }
    }
}
