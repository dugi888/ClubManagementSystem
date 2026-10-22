# Club Presentation and Management project

To see what I intended at the first place and how the progress is going, see the [Idea](./Idea-and-Progress-docu/Idea.md) for idea and [Progress](./Idea-and-Progress-docu/Progress.md).

This project is a backend for a club presentation and management platform. The main goal is to provide a platform for clubs to present themselves and manage their activities, players, and staff.

## Basic info
Used:
- C# with .NET Core 10

## System design

- _Modular Monolith_ with _Domain Driven Design_
- *MVC* on presentation layer - returning JSONs instead of classic Views


| Module               | Responsability                                                | DDD weight | Reason                                                                               |
|----------------------|---------------------------------------------------------------|------------|--------------------------------------------------------------------------------------|
| Identity And Access  | Users, login, roles; who belongs to which club/category (age) | /          | Using ASP.NET Identity, Supporting                                                   |
| Club Directory       | Club, categories (U13, U15..), players, staff etc             | Light      | Simple CRUD                                                                          |
| NewsLetter           | Club news and events                                          | Light      | Simple CRUD                                                                          |
| Competitions         | Matches, results, fixtures                                    | Medium     | Light now - using external API; until we  develop our match stream system            |
| Training             | Weekly plans, attendance, tactics...                          | Heavy      | Planning process, and the core of the app                                            |
| Match Analysis       | Video posts, comments                                         | Heavy      | Publishing video analysis, sorting it (by players, teams etc), visibility to players |
| Larning / Quiz (TBD) | quizzes for match analysis, scoring system, questions etc     | Medium     | /                                                                                    |



## Disclaimer
This project is being developed for educational purposes without AI code assistance. 
The only time I am using AI is for comparing two different ideas (ie. why X is better than Y) mostly in design process.
