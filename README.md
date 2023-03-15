[![Hack Together: Microsoft Graph and .NET](https://img.shields.io/badge/Microsoft%20-Hack--Together-orange?style=for-the-badge&logo=microsoft)](https://github.com/microsoft/hack-together)

## **Project Name:** Nirmal - Hack Together - Sample

## **Project Description:**

#### I have taken this project to understand how to use Microsoft Graph API with .net SDK.
#### I have picked following 2 scenarios and built an console app.

#### - Setup a Teams meeting and return the URL
#### - Send a message to a Teams channel

## **How to execute the project?:**

#### As I have mentioned, this is a console app. Execute the application using Visual Studio or command prompt.

#### Once the application is launched, it will prompt you to enter a scenario.

#### Press 1 -> 'Setup a Teams meeting and return the URL'
#### Press 2 -> 'Send a message to a Teams channel'

## Option 1: `Setup a Teams meeting and return the URL`

### This scenario will allow the user to setup a meeting in 'PACIFIC STANDARD TIME'. After the meeting is setup, the user can see the meeting URL which will be returned as output and the same will be reflected on  user(host) & invited attendee(s) Outlook calendar.

#### After pressing the option 1:

### Following are the input fields which will be excepted by the user to enter:

### 1. Application (Client) ID * 
 - #### This field will be the application ID registered in Azure Active Directory. [string]
### 2. Event Subject Name * 
 - #### This field will be the name of the meeting. [string]
### 3. Event Content * 
 - #### This field will be the meeting email content. [string]
### 4. Meeting StartDate * 
 - #### This field will be the meeting start date in (dd/mm/yyyy) format. [string]
### 5. Meeting StartTime * 
 - #### This field will be the meeting start time in (hh:mm) format. [string]
### 6. Meeting EndDate * 
 - #### This field will be the meeting end date in (dd/mm/yyyy) format. [string]
### 7. Meeting EndTime * 
 - #### This field will be the meeting end time in (hh:mm) format. [string]
### 8. Event Location * 
 - #### This field will be the meeting location. [string]
### 9. Required Attendee(s) * 
 - #### This field will be the attendee's email address. Application will allow you to enter more than one attendee [collection of string].
### 10. Optional Attendee(s)
 - #### Similar to above, but this field is optional.

#### After entering all the above fields. Application will validate (except optional attendee rest all fields is mandatory) and send the details to Graph API to book an event. 
#### On `success`, the application will return the `meeting URL (teams meeting URL)`. Same can be verified in sender/attendee(s) outlook calendar
#### On `failure`, error message details will be displayed with the reason for failure.

#### Please note, while the app interacting with graph, it will prompt you enter user's azure login credentials and prompt for a consent to specific scopes. I will put down the list of scopes used by the application in a seperate section of this page.

### **Demo - Video**

https://6yjrg6-my.sharepoint.com/:v:/g/personal/admin_nak_6yjrg6_onmicrosoft_com/EYo0Vbx5hqhBqiBFrJcSFzMB_KLbjZxlT7sI9LVGNmnzhQ?e=Ji7NgT

## Option 2: `Send a message to a Teams channel`

### This scenario will allow the user to post a message to a specific team & channel.

#### After pressing the option 2:

### Following are the input fields which will be excepted by the user to enter:

### 1. Application (Client) ID * 
 - #### This field will be the application ID registered in Azure Active Directory. [string]

#### After entering the application id, the app will prompt the user to enter azure user credentials to connect with graph api, to pull the list of teams/channels in which the user is member of.
#### Once the list is displayed, the user will be asked to select the Team/channel to send a message (Please enter only the number against the displayed list).

#### After selecting the team/channel, the user will be prompted to enter a message to the channel. 

### 2. Message * 
 - ### This field will be the message that will be posted in the channel. [string]

#### Once done, press the enter key. 

#### Application will validate and passed on the details to graph api, one more time user will be prompted to enter azure user credential with a consent to the list of scopes accessed by the application. 
#### On `success`, the application will return `Message posted successfully.`
#### On `failure`, error message details will be displayed with the reason for failure.

### **Demo - Video**

https://6yjrg6-my.sharepoint.com/:v:/g/personal/admin_nak_6yjrg6_onmicrosoft_com/EbK9vjZTRxJIr9hg7Ggnl9wByiVpiL6ZnTlMW8fuHHVojg?e=zNEQ0m


Unfortunately, in the above video online ms teams stopped working in safari browser, below video-demo explains the output using edge browser.

https://6yjrg6-my.sharepoint.com/:v:/g/personal/admin_nak_6yjrg6_onmicrosoft_com/ERttLk3DpldPvfL3zaBBcocB7I3Rdjpo5stgXzd-lhvVKw?e=XgkhXV

## Used Scopes:

- #### Calendars.ReadWrite - To create an online meeting event.
- #### Team.ReadBasic.All; Channel.ReadBasic.All - To get the teams & channel details in which the user is member of.
- #### ChannelMessage.Send; Group.ReadWrite.All - To post a message to a channel.