## Basic Bank Test - BHUVIT + Accolite
### Yuri Fontoura
---
## About the code
### Architecture
The layers have these main Responsibilities :

* Web API: Just be a facade. Catch data from request or front-end tech. Maybe validate front-end things like formats or authentication (_not implemented_);
* Application Interface: Be the contract of the main processes of the application;
* Application: This one hold the main processes of the system. It must be work like a orchestrator/conductor. It specifies **when** something need to happen;
* Domain: Responsible to be the main core of the business logic and entities. Sometimes hold the contracts, like this one is doing for repository interfaces. It specifies **how** something need to happen;
* Repository: Responsible to hold the database lib and specifications; handle specific db exceptions; maybe, hold classes that are the reflection of table and then mapped to domain classes;
* Cross Domain: This is "just" a configuration layer for avoid hard-coupling/dependency  of libraries. Usually responsible for dependency injection settings.

### Web API
It is running over Swagger, and that is enough to test all the persistence and the business logic.
If you want me to develop a customized UI in another front-end tech, just reach me out please.

### Application
About the interface layer and web api layer, I see that the correct concept for hexagonal architecture is by creating a DTO and isolate the
.Domain entities from any layer outside of it and map with some lib.
But, once that I was allowed even to implement business logic inside the front end layer, so I guess that is okay.

### Business logic
Although  there is no default value set on add a new Account by web api, once there was no rule for insert this entity
with the same rule of max deposit, I did not implement it and let it insert the Balance freely.

---

### I hope you like my solution, I enjoy to develop this test and I do appreciate the opportunity.
