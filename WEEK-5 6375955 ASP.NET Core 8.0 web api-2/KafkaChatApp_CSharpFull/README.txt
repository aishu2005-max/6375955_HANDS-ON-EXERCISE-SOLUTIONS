# KafkaChatApp (C# Windows Forms + Kafka)

## Build
1. Install .NET 8 SDK (or open in Visual Studio 2022 or later).
2. Open `KafkaChatApp_CSharpFull.sln`.
3. Restore NuGet packages (Confluent.Kafka).
4. Build & Run.

## Configure
Kafka is expected at `localhost:9092` and topic `chat_topic`.

## Run Steps (after Kafka running)
- Start 1st instance (F5 in VS).
- Open `bin\Debug\net8.0-windows\KafkaChatApp.exe` a 2nd time for another client.
- Send messages. All clients receive them (unique consumer group per instance).

See top-level batch files to start Kafka quickly on Windows (short path safe).
