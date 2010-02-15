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
        private Rectangle z_viewPort;
        private bool z_isLoaded;

        //Constructor
        public MainMenuScreen(Rectangle viewPort)
        {
            this.z_MainScreenPicture = null;
            this.z_CurrentState = MainMenuState.Missions;
            this.z_viewPort = viewPort;
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
        public void setViewPort(Rectangle viewPort)
        {
            this.z_viewPort = viewPort;
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
            //Save some lines of code -->
            //By checking that none of the keys are being held down here
            if (previousKeyboardState.IsKeyUp(Keys.Up) && previousKeyboardState.IsKeyUp(Keys.Down) &&
                previousKeyboardState.IsKeyUp(Keys.Right) && previousKeyboardState.IsKeyUp(Keys.Left))
            {
                switch (this.z_CurrentState)
                {
                    //If state is Missions, can only move right and down
                    //right is ship state
                    //down is Achievements state
                    case MainMenuState.Missions:
                        {
                            //if player wants to go right
                            if (currentKeyboardState.IsKeyDown(Keys.Right))
                            {
                                this.z_CurrentState = MainMenuState.Ship;
                            }
                            //if player wants to go down
                            if (currentKeyboardState.IsKeyDown(Keys.Down))
                            {
                                this.z_CurrentState = MainMenuState.Achievements;
                            }
                            break;
                        }
                    //If state is Ship, can move left, right, and down
                    //left is missions
                    //right is store
                    //down is options
                    case MainMenuState.Ship:
                        {
                            //if player wants to go right
                            if (currentKeyboardState.IsKeyDown(Keys.Right))
                                this.z_CurrentState = MainMenuState.Store;

                            //if player wants to go down
                            if (currentKeyboardState.IsKeyDown(Keys.Down))
                                this.z_CurrentState = MainMenuState.Options;

                            //if player wants to go left
                            if (currentKeyboardState.IsKeyDown(Keys.Left))
                                this.z_CurrentState = MainMenuState.Missions;

                            break;
                        }
                        //If state is Store, can move only left and down
                        //Left is Ship
                        //Down is Back
                    case MainMenuState.Store:
                        {
                            //if player wants to go Left
                            if (currentKeyboardState.IsKeyDown(Keys.Left))
                                this.z_CurrentState = MainMenuState.Ship;

                            //if player wants to go Down
                            if (currentKeyboardState.IsKeyDown(Keys.Down))
                                this.z_CurrentState = MainMenuState.Back;

                            break;
                        }
                        //If state is Achievements, can only move up and right
                        //Up is missons
                        //Right is Options
                    case MainMenuState.Achievements:
                        {
                            //if player wants to go right
                            if (currentKeyboardState.IsKeyDown(Keys.Right))
                                this.z_CurrentState = MainMenuState.Options;

                            //if player wants to go Up
                            if (currentKeyboardState.IsKeyDown(Keys.Up))
                                this.z_CurrentState = MainMenuState.Missions;

                            break;
                        }
                        //If State is Options, can move left, Up, and right
                        //left is achievements
                        //Up is Ship
                        //Right is Back
                    case MainMenuState.Options:
                        {
                            //if player wants to go Left
                            if (currentKeyboardState.IsKeyDown(Keys.Left))
                                this.z_CurrentState = MainMenuState.Achievements;

                            //if player wants to go Up
                            if (currentKeyboardState.IsKeyDown(Keys.Up))
                                this.z_CurrentState = MainMenuState.Ship;

                            //if player wants to go right
                            if (currentKeyboardState.IsKeyDown(Keys.Right))
                                this.z_CurrentState = MainMenuState.Back;

                            break;
                        }
                        //If state is back, can move left and up
                        //left is Options
                        //Up is Store
                    case MainMenuState.Back:
                        {
                            //if player wants to go Left
                            if (currentKeyboardState.IsKeyDown(Keys.Left))
                                this.z_CurrentState = MainMenuState.Options;

                            //if player wants to go Up
                            if (currentKeyboardState.IsKeyDown(Keys.Up))
                                this.z_CurrentState = MainMenuState.Store;

                            break;
                        }
                    default:
                        break;
                }
            }

        }

        //Draw Method
        public void Draw(SpriteBatch spriteBatch)
        {
            //Don't draw anything if the MainMenuScreen is not yet loaded.
            if (!this.z_isLoaded || this.z_MainScreenPicture == null)
                return;

            //Create a new Vector that will scale the background
            Vector2 ScaledVec = new Vector2(((float)this.z_viewPort.Width / this.z_MainScreenPicture.Width),
                                ((float)this.z_viewPort.Height / this.z_MainScreenPicture.Height));

            spriteBatch.Draw(this.z_MainScreenPicture, new Vector2(0, 0), null, Color.White,
                             0, new Vector2(0, 0), ScaledVec, SpriteEffects.None, 1);

            //Implement the different MainMenuOption States later
            switch (this.z_CurrentState)
            {
                case MainMenuState.Missions:
                    {

                        break;
                    }
                case MainMenuState.Ship:
                    {

                        break;
                    }
                case MainMenuState.Store:
                    {

                        break;
                    }
                case MainMenuState.Achievements:
                    {

                        break;
                    }
                case MainMenuState.Options:
                    {

                        break;
                    }
                case MainMenuState.Back:
                    {

                        break;
                    }




            }
        }


        //Required Load Method
        public void loadTexture(ContentManager content)
        {
            this.z_MainScreenPicture = content.Load<Texture2D>("Content\\Screens\\MainMenuScreen");
            this.z_isLoaded = true;
        }

    }
}
