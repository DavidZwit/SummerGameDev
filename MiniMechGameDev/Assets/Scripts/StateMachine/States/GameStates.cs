using UnityEngine;

namespace GameStates
{

    public class Idle : State
    {
        GameObject obj;
        StatesEnum returnState;

        GameObject LeftVieuw, RightVieuw;

        public Idle(GameObject _LeftVieuw, GameObject _RightVieuw)
        {
            LeftVieuw = _LeftVieuw;
            RightVieuw = _RightVieuw;
        }

        public void Enter(GameObject theObject)
        {
            NonDestroyableData.GameSpeed = 1;


            if (Ball.Instance.isLeftPlayer)
            {
                LeftVieuw.transform.AnimateCameraToMe(1.0f, Vector3.zero, CameraShaker.Instance.OverwriteOrigin);
            }
            else RightVieuw.transform.AnimateCameraToMe(1.0f, Vector3.zero, CameraShaker.Instance.OverwriteOrigin);
        }

        public bool Reason()
        {
            /*if(PlayerPos is in a Chunk)
			{
				returnState = StatesEnum.slomo;
				return false;
			}

			*/

            if (NonDestroyableData.currentChunck != null)
            {
                returnState = StatesEnum.slomo;
                return false;
            }

            return true;
        }

        public void Act()
        {

        }

        public StatesEnum Leave()
        {
            return returnState;
        }
    }


    public class Slomo : State
    {
        GameObject obj;
        StatesEnum returnState;

        bool shouldReturn = false;
        float startTime;
        float timeLeft;

        GameObject topVieuw;




        public Slomo(GameObject _topVieuw)
        {
            topVieuw = _topVieuw;
        }

        Ball _ball;
        public void Enter(GameObject theObject)
        {

            /*
			 * 
			 * GetComponent solution of the combination
			 * Set it into a variable.
			 */
            NonDestroyableData.GameSpeed = 0.2f;

            startTime = Time.time;
            timeLeft = Time.time;
            shouldReturn = false;


            topVieuw.transform.AnimateCameraToMe(1.5f, Vector3.zero, CameraShaker.Instance.OverwriteOrigin);

            returnState = StatesEnum.idle;

            NonDestroyableData.currentChunck = null;
        }

        public bool Reason()
        {
            /*
			 * if(Player Input is the same as the solution)
			 * {
			 * 		ReturnState = StatesEnum.Good;
			 * 		return false;
			 * }
			 * 
			 * if(2 seconds have past)
			 * {
			 * 		returnState = StatesEnum.Bad;
			 * 		return false;
			 * }
			 */

            if (Ball.Instance.UpdateScore)
            {
                returnState = StatesEnum.good;
                return false;
            }
            else if (shouldReturn)
            {
                returnState = StatesEnum.bad;
                return false;
            }

            return true;
        }

        public void Act()
        {
            if (timeLeft - startTime >= 2 && timeLeft - startTime <= 2.1f)
            {
                Ball.Instance.ShootTheBallFromState();
            }
            if (timeLeft - startTime >= 3)
            {
                Exit();
            }
            else timeLeft += Time.deltaTime;
        }

        public StatesEnum Leave()
        {
            //Ball.Instance.ShootTheBallFromState ();
            NonDestroyableData.GameSpeed = 1f;
            return returnState;
        }

        void Exit()
        {
            shouldReturn = true;
        }
    }


    public class Bad : State
    {
        GameObject obj;
        StatesEnum returnState;

        public void Enter(GameObject theObject)
        {
            // ScoreManager.Instance.Scores.AddToFails(1);
            /* 
			 * -1 point/backup
			 * return false; ( back to idle );
			*/

        }

        public bool Reason()
        {
            if (ScoreManager.Instance.Scores.CurrFails == 3)
            {
                NonDestroyableData.players[NonDestroyableData.currPlayer] = ScoreManager.Instance.Scores.CurrScore;

                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                //SortPlayers.Instance.Sort();


            }
            else
                returnState = StatesEnum.idle;
            return false;
        }

        public void Act()
        {

        }

        public StatesEnum Leave()
        {
            return returnState;
        }
    }


    public class Good : State
    {
        GameObject obj;
        StatesEnum returnState;

        public void Enter(GameObject theObject)
        {
            /*
			 * +1 point/backup
			 * return false; ( back to idle );
			*/
        }
        public bool Reason()
        {
            returnState = StatesEnum.idle;
            return false;
        }

        public void Act()
        {

        }
        public StatesEnum Leave()
        {
            return returnState;
        }
    }
}