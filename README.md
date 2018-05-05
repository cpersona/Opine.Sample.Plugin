# Opine.Sample.Plugin
Event-sourced sample for the Opine framework

## Getting Started

### Cloning and building

First, clone the Opine Framework and build it.

```
git clone https://github.com/cpersona/Opine
cd Opine
dotnet build
code .
cd ..
```

Then clone the sample and build it. It should sit as a sibling to Opine.

```
git clone https://github.com/cpersona/Opine.Sample.Plugin
cd Opine.Sample.Plugin
dotnet build
code .
cd ..
```

### Running the sample

In VSCode, debug the Opine framework using the "Go Opine.Job" launch task. (Press F5). 
This will run through commands in the message store and dispatch them. Change launch.json
and replace "commands" with "events" to run through events and call projections.

In an actual test or production environment, you would have separate instances running,
one for commands and one for events. 

## Key Concepts

### Aggregate

The CustomerAggregate is responsible for ensuring consistency within the Customer root. 
You can create customer, add a subscription, or end the current subscription. The 
following events are raised:
- Created
- SubscriptionAdded
- SubscriptionRemoved

### Command handler

The CustomerCommandler class handles commands sent to a Customer. The following commands 
are handled:
- Create
- AddSubscription
- RemoveSubscription

### Projections

The CustomerProjection and CustomerSubscriptionProjections handle events and would be used
to project data into respective tables in a database. These classes will be called when 
processing the "events" stream (-s option in launch.json).

### Message store

The SampleMessageStore is a simple in-memory message store used to simulate a store such 
as EventStore. It is pre-loaded with events and commands to allow for testing command 
handling and event handling.

### Unit of work

The SampleUnitOfWork is a no-op class. In a real scenario, we would persist data to EventStore
after commands have been processed or to a database after events have been processed and projections 
have run.

### Snapshot store

The SampleSnapshotStore is a no-op class. In a real scenario, we would persist and load snapshots
to EventStore or to a relational database table depending on requirements. 


