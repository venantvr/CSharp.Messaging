# CSharp.Messaging

Patterns de messaging en C# avec MassTransit et RabbitMQ : publish/subscribe avec sérialisation de messages typés.

## Structure

- `Contracts/` — Interfaces et messages partagés (YourMessage1, YourMessage2, IHeaders)
- `MassTransit/` — Serveur de bus de messages
- `MassTransitClient/` — Client publisher/subscriber
  - `MyPublisher.cs` — Publication de messages
  - `MySubscriber.cs` — Consommation de messages
- `RabbitMQClient/` — Client RabbitMQ direct (sans MassTransit)

## Stack

[![Stack](https://skillicons.dev/icons?i=dotnet,rabbitmq,cs&theme=dark)](https://skillicons.dev)