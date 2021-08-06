# Learning React.js with Danhoesaur

## What is React.js?
React.js is a [component-based](https://reactjs.org/static/eb8bda25806a89ebdc838813bdfa3601/6b2ea/thinking-in-react-components.png) framework, developed and used for [Facebook](https://facebook.com/).
It's a very popular framework among website developers, and you find most popular websites use it, such as [Facebook](https://facebook.com) (duh), [Twitter](https://twitter.com), [Twitch](https://twitch.tv), [Discord](https://discord.com), [Mojang](https://minecraft.net), [Blizzard Entertainment](https://blizzard.com), [Rockstar Games](https://socialclub.rockstargames.com), [Epic Games](https://www.epicgames.com) and even [dr.dk](https://dr.dk) & [e-boks](https://e-boks.com/danmark/da)

I don't know how to explain things, so instead, you should [listen to ma boi Mosh](https://www.youtube.com/watch?v=N3AkSS5hXMA)...

*pst do yourself a favor and install the [Chrome React Developer Tools Extension](https://chrome.google.com/webstore/detail/react-developer-tools/fmkadmapgofadopljbjfkapdkoienihi), so you can see your components in inspection*

## Install

### Must have:
* Node.js to use `npm install <module>`
* npx & create-react-app => `npm i npx create-react-app -g`
You will then have installed Node.js on your computer, and installed the packages "npx" & "create-react-app" to your global node_modules. This will reduce you having to re-install npx and create-react-app whenever you want to make a new React.js project.

### Creating the project
Open terminal in **Administrator mode** - otherwise, installation may error.

Run `cd C:/Users/User/Desktop/LearnReact` to go to your "LearnReact" folder on your Desktop.
Create the project like so: `npx create-react-app .` - **Note** the . is creating the project in the source folder (LearnReact); replacing this with a name, "MyProject", will create a folder called "MyProject" as the source of the project.

**Useful external packages**
Once installation is done, run the following:
* `npm i nodemon` - This installs nodemon, a module restarting your program every time you save a file; making development much easier.
* `npm i --save-dev @types/react @types/react-dom` - This installs the type definitions for the "react" and "react-dom" module, that installed when you ran the npx create-react-app command. This is so you can read the "internal documentation" / type definitions when coding, so you know what types you're working with.

**Modifying the npm start command**
Inside your LearnReact folder, there is now a package.json file. It will have a section like this:
```json
"scripts": {
    "start": "react-scripts start",
    "build": "react-scripts build",
    "test": "react-scripts test",
    "eject": "react-scripts eject"
}
```
Edit the **start** property to
```json
"scripts": {
    "start": "react-scripts start ; nodemon index.js",
    "build": "react-scripts build",
    "test": "react-scripts test",
    "eject": "react-scripts eject"
}
```
This is so nodemon starts when the React project starts, so nodemon actually works, and we didn't install it for no reason.

## Starting the project
To start the project, run `npm start` in a terminal, and it should magically open a browser for you with some boilercode generated from the npx create-react-app command.

## 