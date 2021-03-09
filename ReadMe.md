# Fitness
## _Get Into It_

[![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Unofficial_JavaScript_logo_2.svg/240px-Unofficial_JavaScript_logo_2.svg.png)](https://www.javascript.com/)

[![N|Solid](https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Octicons-mark-github.svg/240px-Octicons-mark-github.svg.png)](https://github.com/tuganbraden/BlueBadgeChallenge)

# Fitness

Fitness is a C# program that helps you meet your health needs by suggesting diets and workouts based on your unique input
Fitness provide users with an all-in-one application to organize their health information and to establish workouts with their personal goals in mind.

## Features
- Create your own workout plans or browse our list of workout plans
- Get diet suggestions based on your personal needs

## Description
Create User Profile  
Get User Diet  
Allow User to create WorkoutPlans  
Display User WorkoutPlans  
Display User by Diet type  
Edit User info  
Edit Diets  
Edit WorkoutPlans  
Use Diets and User goals to determine a workout severity  
Suggest Diets based on dietary needs  
Add other User as Friends  
View Friends Diet plan  

## Installation

Fitness can be downloaded from Github and run locally 

```bash
https://github.com/tuganbraden/BlueBadgeChallenge
```
You will need the following NuGet packages
```bash
EntityFramework
Microsoft.ASPNet.Identity.Core
Microsoft.ASPNet.Identity.EntityFramework
Microsoft.ASPNet.Identity.Owin
Microsoft.ASPNet.WebApi.Client
Microsoft.ASPNet.WebApi.Core
Microsoft.ASPNet.WebApi.Owin
Microsoft.Owin
Microsoft.Owin.Security
Microsoft.Owin.Security.Cookies
Microsoft.Owin.Security.OAuth
Newtonsoft.Json
Owin
```

## Usage

```bash

API	Description
POST api/User/Register	


GET api/User/GetAll	


GET api/User/GetUserInfo?userId={userId}	


GET api/User/UserInfo	


PUT api/User/Edit	


PUT api/User/AdminEdit?UserId={UserId}&FullName={FullName}&Height={Height}&Weight={Weight}&GoalWeight={GoalWeight}&GoalDate={GoalDate}&SubscriberStatus={SubscriberStatus}&WeeklyCaloricNeed={WeeklyCaloricNeed}&BodyType={BodyType}&LifeStyleType={LifeStyleType}&IsVegetarian={IsVegetarian}&IsKeto={IsKeto}&IsLactoseFree={IsLactoseFree}&IsGlutenFree={IsGlutenFree}&DietId={DietId}	


DELETE api/User/DeleteUserById?userId={userId}	


POST api/User/Logout	


GET api/User/ManageInfo?returnUrl={returnUrl}&generateState={generateState}	


POST api/User/ChangePassword	


POST api/User/SetPassword	


POST api/User/AddExternalLogin	

POST api/User/RemoveLogin	


GET api/User/ExternalLogin?provider={provider}&error={error}	


GET api/User/ExternalLogins?returnUrl={returnUrl}&generateState={generateState}	


POST api/User/RegisterExternal	


Diets
API	Description
GET api/Diets/GetAll	


POST api/Diets	


GET api/Diets/{Id}	


GET api/Diets	


PUT api/Diets	


DELETE api/Diets/{Id}	


Admin
API	Description
PUT api/Admin/Register?userId={userId}	


GET api/Admin/GetAll	


GET api/Admin/IsAdmin?userId={userId}	


DELETE api/Admin/RemoveStatus?userId={userId}	


Friends
API	Description
POST api/Friends	


GET api/Friends	
No documentation available.

DELETE api/Friends	


GET api/Friends?friendId={friendId}	


WorkoutPlan
API	Description
GET api/WorkoutPlan	


GET api/WorkoutPlan/{id}	

POST api/WorkoutPlan	


PUT api/WorkoutPlan	


DELETE api/WorkoutPlan/{id}	

```
#Resources
```bash
https://www.makeareadme.com  
https://dillinger.io/
https://www.medicinenet.com/mediterranean_diet/definition.htm
https://www.healthline.com/nutrition/ketogenic-diet-101
https://www.mayoclinic.org/healthy-lifestyle/nutrition-and-healthy-eating/in-depth/dash-diet/art-20047110#:~:text=Dietary%20Approaches%20to%20Stop%20Hypertension,that%20help%20lower%20blood%20pressure.
https://www.hsph.harvard.edu/nutritionsource/healthy-weight/diet-reviews/paleo-diet/
https://www.tutorialsteacher.com/webapi/create-web-api-project
```

## Contributing
Fitness is not currently open for outside contributors 

## License
Braeger, Kulka & Tugan, 2021