namespace przykladowy_1_client.Dtos;

public class ClientDto : CreateClientDto
{
    public CarServiceDto CarService { get; set; } = null!;
}