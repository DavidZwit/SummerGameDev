using UnityEngine;

namespace GameStates
{
    public class Idle : State
    {
        GameObject obj;
        StatesEnum returnState;

        public void Enter(GameObject theObject)
        {
			Debug.Log (" Idle Enter ");
        }

        public bool Reason()
        {
			/*if(PlayerPos is in a Chunk)
			{
				returnState = StatesEnum.slomo;
				return false;
			}

			*/
			returnState = StatesEnum.slomo;
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

        public void Enter(GameObject theObject)
        {
			Debug.Log (" Slomo Enter ");

			/*
			 * 
			 * GetComponent solution of the combination
			 * Set it into a variable.
			 */
			NonDestroyableData.GameSpeed = 0.2f;
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

            return true;
        }

        public void Act()
        {

        }

        public StatesEnum Leave()
        {
			NonDestroyableData.GameSpeed = 1f;
            return returnState;
        }
    }


    public class Bad : State
    {
        GameObject obj;
        StatesEnum returnState;

        public void Enter(GameObject theObject)
        {
			Debug.Log (" bad Enter ");

			/* 
			 * -1 point/backup
			 * return false; ( back to idle );
			*/
        }

        public bool Reason()
        {
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


    public class Good : State
    {
        GameObject obj;
        StatesEnum returnState;

        public void Enter(GameObject theObject)
        {
			Debug.Log (" Good Enter ");
			/* 
			 * +1 point/backup
			 * return false; ( back to idle );
			*/
        }
        public bool Reason()
        {
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
}