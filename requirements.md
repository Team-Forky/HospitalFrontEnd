# Software Requirements
## Vision:
- The vision of this product is a hospital management system that allows fast, easy, accurate presentation of data for use by staff of a medical facility about patients and hospital resources.
- Medical facilities, especially those set up in emergencies, need a tool to help coordinate and track patients and resources in a chaotic environment. Our app tracks the data digitally and makes it easily accessible.
- The emergency response to the COVID-19 pandemic needs good tools at its disposal in order to save lives and reduce the strain on the everyday staff fighting on the front lines. This app is for them.

## Scope:
- In:
  - Our project will enable creating, reading, updating, and deleting of data for patients of the hospital
  - Our project will enable users to get a list of patients or see details about a single patient.
  - Our project will have a front-end MVC web app to display the data, and a backend MVC api server connected to a database to store the data.
  - Our project will be deployed in Azure

- Out:
  - Our project will not have patients as primary users
  - Our project will not process insurance information
  - Our project will not process payments
  - Our project will not authenticate user accounts
  - Our project will not have unit testing, because we have not had the chance to learn about unit testing with Azure
  - Our project will not do actual medical work
  - Our project will not do medical research
  - Our project will not have real patient data

### MVP
- Allow the viewing of a list of all patients as well as details for a single patient
- Details for each patient will include an ID#, name, birthday, status, and the date/time they checked in.
- Patients will be listed by how critical their condition is, with the most critical patients at the top of the list.
- Patients can be added, updated, and deleted from the database by the user.

### Stretch goals
- Have different user profiles for doctors, facility admins, etc with different permissions and access.
- Allow sorting of patients by various criteria including needed criticality and needed equipment.
- Page for viewing equipment inventory, showing available vs in-use equipment.
- Additional patient information, such as medical history, allergies, pictures, insurance info, diagnoses, needed procedures, and doctor's notes
- Data is processed to generate status of the facility
- Actual medical codes implemented

## Functional Requirements
- User can see the home page
- User can navigate to the patients page
- User can see a list of patients on the patients page
- User can add patients to the list
- User can navigate to details about individual patients
- User can update or delete information for individual patients
- User can navigate to the about us page
- User can see information about us, the developers, in the about us page

### Data Flow
- The user loads the home page, and navigates to the patients page.
- The user's request for the patients page is sent to the front-end.
- The front-end sends a request for patient data to the backend server.
- The backend server sends a request to the database for patient data as a SQL query via LINQ request.
- The database transforms the data into JSON and sends that patient data to the backend server.
- The backend server converts the patient data from the database to Data Transfer Objects and sends those DTOs to the front-end as JSON.
- The front-end converts the recieved JSON objects to C# objects via JSON deserializer and sends the data to a view.
- The front-end parses the data within the view, and sends the view to the user.

- To update the data in the database, the user modifies information about a patient in a form and submits that form to the front-end.
- The front-end converts the form data into an object and converts that object into JSON to send to the backend server.
- The backend server converts the JSON into an object
- The backend server creates a SQL query based on the object and queries the database to update the data there.

## Non-functional requirements
- Patient data must be secure, up to date, and quickly retrieved.
- Viewing, adding, updating, or deleting patient data should be easy and secure.
- Users should be able to use the app via internet connection, not just from the machine on which the app was created.
