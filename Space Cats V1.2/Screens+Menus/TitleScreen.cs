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
using System.Text;

namespace Space_Cats_V1._2
{
    class TitleScreen : IScreenMenu
    {
        //Enum
        public enum TitleState
        {
            Start,
            Options,
            Exit

        }


        //Instance Variables
        private Texture2D z_logo;
        private Texture2D z_options;
        private GameObject z_arrow;
        private TitleState z_currentState;
        private bool z_isLoaded;

        //Constructor
        public TitleScreen()
        {
            this.z_currentState = TitleState.Start;
            this.z_isLoaded = false;
        }

        //Accessors
        public Texture2D getLogo()
        {
            return this.z_logo;
        }
        public Texture2D getOptions()
        {
            return this.z_options;
        }
        public GameObject getArrow()
        {
            return this.z_arrow;
        }
        public TitleState getState()
        {
            return this.z_currentState;
        }
        public bool getIsLoaded()
        {
            return this.z_isLoaded;
        }


        //Mutators
        public void setLogo(Texture2D newLogo)
        {
            this.z_logo = newLogo;
        }
        public void setOptions(Texture2D newOptions)
        {
            this.z_options = newOptions;
        }
        public void setArrow(GameObject newArrow)
        {
            this.z_arrow = newArrow;
        }
        public void setState(TitleState newState)
        {
            this.z_currentState = newState;
        }
        public void setIsLoaded(bool isLoaded)
        {
            this.z_isLoaded = isLoaded;
        }


        //Update Method
        public void update(KeyboardState currentKeyboardState, KeyboardState previousKeyboardState)
        {
            //Don't update anything if the titleScreen is not loaded
            if (!this.z_isLoaded)
                return;

            switch (this.z_currentState)
            {
                case TitleState.Start:
                    {
                        if (previousKeyboardState.IsKeyUp(Keys.Down) && currentKeyboardState.IsKeyDown(Keys.Down)
                            && previousKeyboardState.IsKeyUp(Keys.Up))
                        {
                            this.z_currentState = TitleState.Options;
                            this.z_arrow.setPosition(new Vector2(170, 425));
                        }
                        break;
                    }
                case TitleState.Options:
                    {
                        if (previousKeyboardState.IsKeyUp(Keys.Down) && currentKeyboardState.IsKeyDown(Keys.Down)
                            && previousKeyboardState.IsKeyUp(Keys.Up))
                        {
                            this.z_currentState = TitleState.Exit;
                            this.z_arrow.setPosition(new Vector2(170, 490));
                        }
                        else if (previousKeyboardState.IsKeyUp(Keys.Down) && currentKeyboardState.IsKeyDown(Keys.Up)
                                && previousKeyboardState.IsKeyUp(Keys.Up))
                        {
                            this.z_currentState = TitleState.Start;
                            this.z_arrow.setPosition(new Vector2(170, 350));
                        }
                        break;
                    }
                case TitleState.Exit:
                    {
                        if (previousKeyboardState.IsKeyUp(Keys.Down) && currentKeyboardState.IsKeyDown(Keys.Up)
                                && previousKeyboardState.IsKeyUp(Keys.Up))
                        {
                            this.z_currentState = TitleState.Options;
                            this.z_arrow.setPosition(new Vector2(170, 425));
                        }
                        break;
                    }


            }
        }



        //Draw Method
        public void Draw(SpriteBatch spritebatch)
        {
            //Don't draw anything if the titleScreen is not yet loaded.
            if (this.z_logo==null || this.z_options==null || this.z_arrow == null)
                return;

            spritebatch.Draw(this.z_logo, new Vector2(0, 0), Color.White);
            spritebatch.Draw(this.z_options, new Vector2(0, 300), Color.White);
            
            switch (this.z_currentState)
            {
                case TitleState.Start:
                    {
                        spritebatch.Draw(this.z_options, new Rectangle(255, 340, 245, 60), new Rectangle(255, 40, 245, 60), Color.Blue);
                        break;
                    }
                case TitleState.Options:
                    {
                        spritebatch.Draw(this.z_options, new Rectangle(255, 400, 245, 80), new Rectangle(255, 100, 245, 80), Color.Blue);
                        break;
                    }
                case TitleState.Exit:
                    {
                        spritebatch.Draw(this.z_options, new Rectangle(255, 480, 245, 60), new Rectangle(255, 180, 245, 60), Color.Blue);
                        break;
                    }

            }

            spritebatch.Draw(this.z_arrow.getSprite(), this.z_arrow.getPosition(), Color.White);

        }


        //Required Load Method
        public void loadTexture(ref ContentManager content)
        {
            this.z_logo = content.Load<Texture2D>("LogoScreen");
            this.z_options = content.Load<Texture2D>("TitleOptions");
            this.z_arrow = new GameObject(content.Load<Texture2D>("ArrowSelection"));
            //Try to fiqure the starting position for arrow ^^
            this.z_arrow.setPosition(new Vector2(170, 350));
            this.z_isLoaded = true;
        }

    }
}
