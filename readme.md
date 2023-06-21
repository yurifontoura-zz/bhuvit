## Basic Bank Test - BHUVIT + Accolite
### Yuri Fontoura
---
## About the code
### Web API
It is running over Swagger, and that is enough to test all the persistence and the business logic.
If you want me to develop a customized UI in another front-end tech, just reach me out please.

### Application
About the interface layer and web api layer, I see that the correct concept for hexagonal architecture is by creating a DTO and isolate the
.Domain entities from any layer outside of it and map with some lib.
But, once that I was allowed even to implement business logic inside the front end layer, so I guess that is okay.

### Business logic
Althoug there it no default value set on add a new Account by web api, once there was no rule for insert this entity
with the same rule of max deposit, I did not implement it and let it insert the Balance freely.
