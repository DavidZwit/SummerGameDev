using UnityEngine;

namespace GameStates
{
    public class Idle : State
    {
        GameObject obj;
        StatesEnum returnState;

        public void Enter(GameObject theObject)
        {
            NonDestroyableData.GameSpeed = 1;
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

            if (Ball.Instance.UpdateScore) {
                returnState = StatesEnum.good;
                return false;
            } else if (shouldReturn) {
                returnState = StatesEnum.bad;
                return false;
            }

            return true;
        }

        public void Act()
        {
            if (timeLeft - startTime  >= 2) {
                Exit();
            } else timeLeft += Time.deltaTime;
        }

        public StatesEnum Leave()
        {
			Ball.Instance.ShootTheBallFromState ();
			NonDestroyableData.GameSpeed = 1f;
            return returnState;
        }

        void Exit ()
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

            /* 
			 * -1 point/backup
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