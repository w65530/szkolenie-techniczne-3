using Azure.Messaging.ServiceBus;

namespace kolokwium_api.ServicesBusPublisher;

public class ServicesBusQueueSender
{
    private readonly string _connectionString;
    private readonly string _queueName;
    
    private ServiceBusSender _sender;
    
    public ServicesBusQueueSender(string connectionString, string queueName)
    {
        this._connectionString = connectionString;
        this._queueName = queueName;
        ServiceBusClient client = new ServiceBusClient(connectionString);
        _sender = client.CreateSender(queueName);
    }
    
    public async Task SendAsync(string messageContent)
    {
        ServiceBusMessage message = new ServiceBusMessage(messageContent);
        
        await _sender.SendMessageAsync(message);
    }
}