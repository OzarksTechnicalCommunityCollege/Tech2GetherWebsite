# Tech2GetherWebsite - Goals
Our goals for this website are to have a place for Club data to live. Attendance, meeting information, event statistics etc. 
It is a tool for us to keep track of important data with an admin panel and a useful learning experience for those involved. 

## Current Active Authors/Contributors
Paul Bute, Diego Haro, Willhemina Vanderpool

## Tech Stack
ASP.NET Core, Tailwind CSS

## Getting Set Up - Condensed
For a more detailed version please go [Learn how to setup your environment here](https://otccis.gitbook.io/student-help-docs/t2t/setup-your-environment)

Download git, visual studio the .NET SDK, Node.js and docker.

Fork the repository, clone it down and set your upstream remote to the original repo

```bash
# Replace YOUR-USERNAME with your GitHub username
git clone https://github.com/YOUR-USERNAME/Tech2GetherWebsite.git
cd Tech2GetherWebsite
git remote add upstream https://github.com/OzarksTechnicalCommunityCollege/Tech2GetherWebsite.git
```

Navigate to your project root directory if you haven't already, we're going to set up Docker now.

```bash
docker-compose up -d
```
If there is an error try

```bash
dock compose up -d
```

Verify it's running 
```bash
docker ps
```
While we're in our root directory, we'll finish our EF core setup and migrations.

```bash
# Install the EF Core tools (first time only)
dotnet tool install --global dotnet-ef

# Create a migration that will create database tables
dotnet ef migrations add InitialCreate
# ‼️ If you get the error that the name InitialCreate is used already, just skip to the next command.

# Run migrations to create database tables
dotnet ef database update
```

Finally, we'll set up Node.js in our project.
```bash
npm install

npm run build
```

You should be all set up to run the project and make sure things are working.

Visit [how to seed your database](https://otccis.gitbook.io/student-help-docs/t2t/seed-your-database) to finish your database setup. This can be done at a later time if needed.

For a more detailed version please go [Learn how to setup your environment here](https://otccis.gitbook.io/student-help-docs/t2t/setup-your-environment)

If you still have questions, we have bi-weekly website team meetings from 10:20am-11:20am in the PMC. For details, check the CIS discord or reach out to an officer through teams or discord.

## Contributing - Condensed

Fork the repo, clone down
```bash
git remote add upstream https://github.com/OzarksTechnicalCommunityCollege/Tech2GetherWebsite.git
```
Check issues page and select an item to work on.

```bash
# Make sure you're starting from the latest develop branch
git checkout develop
git pull upstream develop

# Create your new branch
git checkout -b feature/add-sponsor-logos
```
Replace add-sponsor-logs with the name of the issue you are working on.

When you are done, push the feature branch and then make a Pull Request to develop (not main!)

```bash
git push origin feature/add-sponsor-logos
```
An officer will review your PR and get back to you with feedback, any neccesary hanges and a status update within a few days.

Need more guidance? You can view our [contributor guide here](https://otccis.gitbook.io/student-help-docs/t2t/tech2gether-website)

If you still have questions, we have bi-weekly website team meetings from 10:20am-11:20am in the PMC. For details, check the CIS discord or reach out to an officer through teams or discord.