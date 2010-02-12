using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Space_Cats_V1._2
{
    class MainMenuScreen : IScreenMenu
    {
        //Enum
        public enum MainMenuState
        {
            Missions,
            Ship,
            Store,
            Achievements,
            Options,
            Back,
            Exit
        }


        //Instance Variables
        private Texture2D z_MainScreenPicture;
        private MainMenuState z_CurrentState;
        private bool z_isLoaded;

        //Constructor
        public MainMenuScreen()
        {
            this.z_MainScreenPicture = null;
            this.z_CurrentState = MainMenuState.Missions;
            this.z_isLoaded = false;
        }


        //Accessors
        public Texture2D getMainScreenTexture()
        {
            return this.z_MainScreenPicture;
        }
        public MainMenuState getCurrentState()
        {
            return this.z_CurrentState;
        }
        public bool getIsLoaded()
        {
            return this.z_isLoaded;
        }

        //Mutators
        public void setMainScreenTexture(Texture2D newTexture)
        {
            this.z_MainScreenPicture = newTexture;
        }
        public void setCurrentState(MainMenuState newState)
        {
            this.z_CurrentState = newState;
        }
        public void setIsLoaded(bool loaded)
        {
            this.z_isLoaded = loaded;
        }

        //Update Method
        public void update(KeyboardState currentKeyboardState, KeyboardState previousKeyboardState)
        {
            //Don't update anything if the MainMenu is not loaded
            if (!this.z_isLoaded)
                return;

            if (previousKeyboardState.IsKeyUp(Keys.Escape) && currentKeyboardState.IsKeyDown(Keys.Escape))
                this.z_CurrentState = MainMenuState.Exit;

            //Implement the other states/input later

        }

        //Draw Method
        public void Draw(SpriteBatch spriteBatch)
        {
            //Don't draw anything if the MainMenuScreen is not yet loaded.
            if (!this.z_isLoaded || this.z_MainScreenPicture == null)
                return;

            spriteBatch.Draw(this.z_MainScreenPicture, new Vector2(0, 0), Color.White);

            //Implement the different MainMenuOption States later
        }


        //Required Load Method
        public void loadTexture(ContentManager content)
        {
            this.z_MainScreenPicture = content.Load<Texture2D>("Content\\Screens\\MainMenuScreen");
            this.z_isLoaded = true;
        }

    }
}
