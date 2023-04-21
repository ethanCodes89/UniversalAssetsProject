# UniversalAssetsProject
This is a project I decided to focus on to build a strong code base with a variety of tools to allow me to quickly prototype games.
My goal is to have many systems built and drop in ready, with a focus on reusabiltiy and extensibility, as well as readability!

Current Systems:
  Save System - The save system is easy to setup with clear documentation. It handles premade scenes and dynamically spawned objects. it will encrypt using AES when
                running in a build, but will NOT encrypt in editor, allowing for the developer to easily manipulate or check save data.
                This system has future additions coming with a more built out API allowing for the option for multiple save files, and an autosave option.
                
  Camera Systems - My goal with the camera systems are to have a folder of different camera scripts that can be easily dropped onto any main camera (or player, or
                  seperate gameobject, depending on use case), and be ready to go. There will be a variety of setting depending on the camera allowing for 
                  deep customization.
                  Currently, there is only an over the shoulder 3rd person camera which still needs some tweaking.
