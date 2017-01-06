using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SingleBoostr
{
    class Game
    {
        public enum direction { idle, left, right, up, down }

        public enum player { player_one, player_two }

        private PictureBox _player1, _player2, _ball, _obst1, _obst2;
        private Label _player1label;
        private mainForm _form;
        private Panel _area;

        public direction player_direction,
            ball_direction,
            obst1_direction = direction.up,
            obst2_direction = direction.down;

        private bool game_on, game_started, hit_object;
        private int player_speed = 2, 
            enemy_speed = 1, 
            ball_speed = 2,
            obst_speed = 1,
            ball_force,
            player_lives = 5,
            score_player1 = 0,
            round;

        private static Random _rand = new Random();

        public Game(mainForm form)
        {
            _form = form;
            _player1 = form.game_Player1;
            _player2 = form.game_Player2;
            _ball = form.game_Ball;

            _player1label = form.game_Player1_Score;
            _area = form.panelGameArea;

            _obst1 = _form.game_Obsticle1;
            _obst2 = _form.game_Obsticle2;
        }

        private void Complete()
        {
            game_on = false;
            _form.game_Timer.Stop();
            _form.game_AITimer.Stop();
            _form.game_YouWon.Visible = true;
        }

        private void Start()
        {
            game_on = false;

            _ball.Location = new Point(260, 118);
            _player1.Location = new Point(12, 110);
            _player2.Location = new Point(511, 110);
            ball_direction = direction.right;
            ball_force = _rand.Next(-1, 2);
            
            _form.game_Timer.Start();
            _form.game_AITimer.Start();

            game_on = true;
        }

        private void Scored(player p)
        {
            round++;
            if (p == player.player_one)
            {
                score_player1++;
                player_lives = 5;
                _player1label.Text = $"Score: {score_player1}/40   -    Lives: {player_lives}";

                /*Make it harder every other goal*/
                switch (score_player1)
                {
                    case 2:
                        ball_speed = 2;
                        break;

                    case 4:
                        ball_speed = 3;
                        break;

                    case 6:
                        ball_speed = 4;
                        enemy_speed = 2;
                        break;

                    case 8:
                        ball_speed = 5;
                        break;

                    case 10:
                        ball_speed = 6;
                        enemy_speed = 3;
                        break;

                    case 12:
                        ball_speed = 7;
                        break;

                    case 14:
                        ball_speed = 8;
                        player_speed = 3;
                        break;

                    case 16:
                        _player1.Height = 25;
                        break;

                    case 18:
                        _player1.Height = 20;
                        break;

                    case 20:
                        _ball.Size = new Size(12, 12);
                        break;

                    case 22:
                        _ball.Size = new Size(10, 10);
                        break;

                    case 24:
                        ball_speed = 9;
                        player_speed = 4;
                        break;

                    case 26:
                        enemy_speed = 4;
                        break;

                    case 28:
                        _ball.Size = new Size(8, 8);
                        break;

                    case 30:
                        _obst2.Visible = true;
                        player_speed = 5;
                        break;

                    case 32:
                        _obst1.Visible = true;
                        break;

                    case 34:
                        obst_speed = 2;
                        break;

                    case 36:
                        obst_speed = 3;
                        break;

                    case 38:
                        obst_speed = 4;
                        break;

                    case 40:
                        Complete();
                        return;
                }
            }
            else
            {
                _player1label.Text = $"Score: {score_player1}/40    -    Lives: {--player_lives}";
            }

            if (player_lives <= 0)
            {
                _form.game_YouWon.Text = "YOU DIED";
                _form.game_YouWon.Visible = true;
                Complete();
            }
            else
                Start();
        }

        public void KeyUp(Keys key)
        {
            player_direction = direction.idle;
        }

        public void KeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.F12:
                    if (!game_started)
                    {
                        _form.game_Instructions.Visible = false;
                        game_started = true;
                        Start();
                    }
                    break;

                case Keys.W: case Keys.Up:
                    player_direction = direction.up;
                    break;

                case Keys.S: case Keys.Down:
                    player_direction = direction.down;
                    break;
            }
        }

        public void ProcessTick()
        {
            if (game_on)
            {
                if (player_direction == direction.up && HasCollided(_player1, _area) != direction.up)
                {
                    _player1.Top -= player_speed;
                }
                else if (player_direction == direction.down && HasCollided(_player1, _area) != direction.down)
                {
                    _player1.Top += player_speed;
                }

                if (ball_force > 0)
                {
                    _ball.Top -= ball_force;
                }
                else if (ball_force < 0)
                {
                    _ball.Top -= ball_force;
                }

                if (_ball.Location.Y <= 1)
                {
                    ball_force = ReverseInt(ball_force, true, true);
                }
                else if (_ball.Location.Y + _ball.Height >= _area.Height - 1)
                {
                    ball_force = ReverseInt(ball_force, true, false);
                }

                if (obst1_direction == direction.up && HasCollided(_obst1, _area) != direction.up)
                {
                    _obst1.Top -= obst_speed;
                }
                else
                {
                    obst1_direction = direction.down;
                    _obst1.Top += obst_speed;

                    if (HasCollided(_obst1, _area) == direction.down)
                        obst1_direction = direction.up;
                }

                if (obst2_direction == direction.up && HasCollided(_obst2, _area) != direction.up)
                {
                    _obst2.Top -= obst_speed;
                }
                else
                {
                    obst2_direction = direction.down;
                    _obst2.Top += obst_speed;

                    if (HasCollided(_obst2, _area) == direction.down)
                        obst2_direction = direction.up;
                }

                if (ball_direction == direction.left)
                {
                    if (HasCollided(_ball, _area) == direction.left)
                    {
                        /*Enemy scored*/
                        Scored(player.player_two);
                    }

                    if (HasCollidedWithObject(_ball, _obst1) || HasCollidedWithObject(_ball, _obst2))
                    {
                        if (!hit_object)
                        {
                            hit_object = true;
                            ball_direction = direction.right;
                            return;
                        }
                    }

                    if (!Collision_Player(_ball, _player1))
                    {
                        _ball.Left -= ball_speed;
                    }
                    else
                    {
                        hit_object = false;
                        ball_direction = direction.right;
                    }
                }
                else
                {
                    if (HasCollided(_ball, _area) == direction.right)
                    {
                        /*Player scored*/
                        Scored(player.player_one);
                    }

                    if (HasCollidedWithObject(_ball, _obst1) || HasCollidedWithObject(_ball, _obst2))
                    {
                        if (!hit_object)
                        {
                            hit_object = true;
                            ball_direction = direction.left;
                            return;
                        }
                    }

                    if (!Collision_Enemy(_ball, _player2))
                    {
                        _ball.Left += ball_speed;
                    }
                    else
                    {
                        hit_object = false;
                        ball_direction = direction.left;
                    }
                }
            }
        }

        public void ProcessEnemyTick()
        {
            int enemySide = _area.Width / 2;
            if (_ball.Location.X > enemySide && ball_direction == direction.right)
            {
                var collided = HasCollided(_player2, _area);
                if (collided != direction.up && collided != direction.down)
                {
                    int ball = _ball.Height - (_ball.Height / 2);
                    if (_player2.Location.Y + ball < _ball.Location.Y)
                    {
                        _player2.Top += enemy_speed;
                    }
                    else
                    {
                        _player2.Top -= enemy_speed;
                    }
                }
                else
                {
                    if (collided != direction.up)
                        _player2.Top -= enemy_speed;
                    else
                        _player2.Top += enemy_speed;
                }
            }
        }

        private direction HasCollided(PictureBox obj, Panel area)
        {
            if (obj.Location.X <= 0)
                return direction.left;
            
            if (obj.Location.X + obj.Width >= area.Width)
                return direction.right;
            
            if (obj.Location.Y <= 0)
                return direction.up;
            
            if (obj.Location.Y + obj.Height >= area.Height)
                return direction.down;

            return direction.idle;
        }

        private bool HasCollidedWithObject(PictureBox obj, PictureBox target)
        {
            if (!target.Visible)
                return false;

            return obj.Bounds.IntersectsWith(target.Bounds);
        }

        private bool Collision_Enemy(PictureBox tar, PictureBox enemy)
        {
            int location = tar.Location.Y + (tar.Height / 2);
            var area = new PictureBox() { Bounds = enemy.Bounds };
            int hitboxHeight = enemy.Height / 7;

            //var ball = new PictureBox() { Bounds = tar.Bounds };
            //ball.Location = new Point(ball.Location.X, location);
            //ball.Size = new Size(ball.Width, 1);

            area.SetBounds(area.Location.X - 1, area.Location.Y, 1, hitboxHeight);
            if (tar.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = 3;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (tar.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = 2;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (tar.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = 1;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (tar.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = 0;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (tar.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = -1;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (tar.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = -2;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (tar.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = -3;
                return true;
            }

            return false;
        }

        private bool Collision_Player(PictureBox tar, PictureBox player)
        {
            int location = tar.Location.Y + (tar.Height / 2);
            var area = new PictureBox() { Bounds = player.Bounds };
            int hitboxHeight = player.Height / 7;

            var ball = new PictureBox() { Bounds = tar.Bounds };
            //ball.Location = new Point(ball.Location.X, location);
            //ball.Size = new Size(ball.Width, 1);

            area.SetBounds(area.Location.X + area.Width, area.Location.Y, 1, hitboxHeight);
            if (ball.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = 3;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (ball.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = 2;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (ball.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = 1;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (ball.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = 0;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (ball.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = -1;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (ball.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = -2;
                return true;
            }

            area.SetBounds(area.Location.X, area.Location.Y + hitboxHeight, 1, hitboxHeight);
            if (ball.Bounds.IntersectsWith(area.Bounds))
            {
                ball_force = -3;
                return true;
            }

            return false;
        }

        private int ReverseInt(int i, bool force = false, bool negative = false)
        {
            if (force)
            {
                if (negative)
                {
                    if (i > 0)
                        i = ~i + 1;
                }
                else
                    i = i - (i * 2);
            }
            else
            {
                if (i > 0)
                    i = i - (i * 2);
                else
                    i = ~i + 1;
            }

            return i;
        }
    }
}
