Sorry I took so long. I think I covered everything. I left some minor comments throughout the code.
I layered everything. I have some crude mapping going on between the domain layer and the datalayer.
The mapping really is doing nothing at this point but changing types, simply because we are not exercising
any overly complex business rules against the domain objects. If we had some complex business business logic
in our domain layer, then the types between the datalayer and business layer would likely have a lot more
differences and warrant mapping. I would normally use a third party mapping library or refactor the mapping
responsibility into its own class. The "Ajax"" view is the pure html view for part 12. I'm using knockout for
the databinding and dirty checking. Knockout seemed the most minimal and quickest approach for part 12.
You'll see for part 11 how I have mvc partially masquerading as a rest api. The seed class for the initial data
is in DataSeeder in App_Start. I made the initial data global by instantiating the repository holding it as a
singleton in the Unity DI container. The seeding is done in the application startup class. The repository is
not thread-safe since I am not locking access to the underlying collection.