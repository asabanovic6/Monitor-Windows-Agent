## Feature 

Ping to server and send json datas

### Item 
Enable connection to server every "keep alive" second and send json datas to server

#### Task

* Create Windows APP and Windows service
* Create a new branch and switch to it
* Create a module for ping  server
* Create model of config file datas  
* Create class which parse datas from config file to model
* Create method for creating json object from model
* Create method to ping server every KeepAlive seconds and send json object 
* Commit and push on your branch
* Create a pull request

## Feature 

Exchanging files and  screenshots with the server

### Item 
Enable sending files with any extension to the server and enable receiving files from the server

#### Task

* Create a new branch and switch to it
* Create a module for connection to the server
* Update a module, making connection stable 
* Create methods for sending files
* Create methods for receiving files
* Create a screen capture method
* Commit and push on your branch
* Create a pull request
* Merge branches 

## Feature 

Event Viewer

### Item 
Enable that each client request can be found in the Event Viewer written as a log containing information about the client requesting a query and information about the type of request

#### Task

* Create a new branch and switch to it
* Create a new module for developing Event Logger methods 
* Create methods in Event Logger
* Commit and push on your branch
* Create a pull request
* Merge branches 

## Feature 

Activation form 

### Item 
Create form for activation of agent 

#### Task

* Create a new branch and switch to it
* Creat a form for activation of agent 
* Create all necessary validations 
* Handle button to send activation code to server 
* Create request for sending code and receiving config file 
* Commit and push on your branch
* Create a pull request
* Merge branches 

## Feature 

Form for tracking configuration file changes

### Item 
Create for tracking configuration file changes and trough the from making connection between server and agent

#### Task

* Create a new branch and switch to it
* Create a form for tracking configuration file changes
* Fill the form with datas from config file which we recieved from server 
* Make fields read only except fields for file locations datas 
* Create all necessary validations 
* Handle refresh button to update form with new datas
* Handle submit button to send configuration file to server
* Enable connection to the server when applications is opened
* Commit and push on your branch
* Create a pull request
* Merge branches 

## Feature 

Error handling

### Item 
Enable logging all runtime errors in the database

#### Task

* Create a new branch and switch to it
* Create a method in module for sending json object with information about device and error to server
* Find all critical parts of the code where a runtime error is possible and call the method
* Make fields read only except fields for file locations datas 
* Commit and push on your branch
* Create a pull request
* Merge branches 

## Feature 

Get usability for cpu, ram, hdd and gpu of computer

### Item 
Allow the application to send CPU, RAM, GPU, and HDD usage data to that server

#### Task

* Create a new branch and switch to it
* Create a method in module for get CPU usage
* Create a method in module for get GPU usage
* Create a method in module for get HDD usage
* Create a method in module for get RAM usage
* Call the created methods and create json object which we send to the server
* Commit and push on your branch
* Create a pull request
* Merge branches 
