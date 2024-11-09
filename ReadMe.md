<h1 align="center" style="font-weight: bold;">Space Pod Mania Showdown</h1>

<p align="center">This is the server-side for the fullstack application called <span><a href="https://github.com/Jgochey/space-pod-mania-showdown">Space Pod Mania Showdowwn</a></span> - a podcast app that builds a community platform for podcast creators and listeners to post, rank, and discover content. </P>

## Table of Conetents
- <a href="#tech-stack">Tech Stack</a>
- <a href="#getting-started">Getting Started</a>
- <a href="#api-endpoints">API Endpoints</a>
- <a href="#postman-documentation">Postman Documentation</a>
- <a href="#colaborators">Collaborators</a>

<h2 id="tech-stack">Tech Stack</h2>

- C#
- .NET
- Entity Framework Core
- Moq
- xUnit
- PostgreSQL
- pgAdmin
- Swagger
- Postman

<h2 id="getting-started">Getting started</h2>

<h3>Prerequisites</h3>

For this project to run, you'll need to install the following:

- [.NET](https://dotnet.microsoft.com/en-us)
- [PostgreSQL](https://www.postgresql.org/download)
- [pgAdmin](https://www.pgadmin.org)

<h3>1. Clone the Repo</h3>

Clone this repo using this command in your terminal:

```bash
git clone git@github.com:britnay268/PodcastAPI.git
```

<h3>2. Install Required Packages</h3>

Once the repository is cloned, navigate to the project directory in your terminal and run the following commands to install necessary packages:

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0
```

<h3>3. Set Up Secrets for PostgreSQL Connection</h3>

To store sensitive connection details, initialize the secret storage with:

```bash
dotnet user-secrets init
```

Then, set the connection string for your PostgreSQL database (replace with your actual PostgreSQL password):

```bash
dotnet user-secrets set "PodcastAPIConnectionString" "Host=localhost;Port=5432;Username=postgres;Password=<your_postgresql_password>;Database=PodcastAPI"
```

<h3>4. Apply Migrations to the Database</h3>

Run the following command to apply the database migrations:

```bash
dotnet ef database update
```

This will create the necessary tables and schema in your PostgreSQL database.

<h3>5. Run the Solution</h3>

Launch the project. Swagger should automatically launch and provide you with the API documentation.

<h2 id="api-endpoints">API Endpoints</h2>

| Episode              |
|----------------------|
| **GET /episodes/{episodeId}**
| **POST /episodes**
| **DELETE /episodes/{id}**
| **PUT /episodes/{id}**
| **GET /users/{userId}/episodes/favorite**
| **PUT /episodes/{episodeId}/toggleFavorite/{userId}**

|Genre                 |
|----------------------|
| **GET /genres**
| **GET /podcasts/genre/{genreId}**

|Podcast               |
|----------------------|
| **GET /podcasts**
| **POST /podcasts**
| **GET /podcasts/favorites/{userId}**
| **GET /podcasts/{podcastId}**
| **PUT /podcasts/{podcastId}**
| **DELETE /podcasts/{podcastId}**
| **PUT /podcasts/{podcastId}/toggleFavorite/{userId}**
| **GET /podcasts/search**
| **GET /podcasts/favorites/{userId}/search**

|ShowdownResult        |
|----------------------|
| **POST /showdown**
| **GET /podcasts/showdown/{genreId}**

|User                  |
|----------------------|
| **POST /checkuser**
| **POST /users**

<h2 id="postman-documentation">Postman Documentation</h2>

Checkout the [Space Pod Mania Showdown](https://documenter.getpostman.com/view/31791227/2sAY52cejq) to learn more about the API endpoints mentioned above!

<h2 id="colaborators">Collaborators</h2>

<table>
<tr>

<td align="center">
<a href="https://github.com/alexberka">
<img src="https://avatars.githubusercontent.com/u/148516337?v=4" width="100px;" alt="Alex Berka's Profile Picture"/><br>
<sub>
<b>Alex Berka</b>
</sub>
</a>
</td>

<td align="center">
<a href="https://github.com/britnay268">
<img src="https://avatars.githubusercontent.com/u/153968439?v=4" width="100px;" alt="Britnay Gore's' Profile Picture"/><br>
<sub>
<b>Britnay Gore/b>
</sub>
</a>
</td>

</tr>
</table>