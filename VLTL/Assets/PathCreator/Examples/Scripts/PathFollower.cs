using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public static PathFollower instance;
        float distanceTravelled;
        int y;

        void Start() {
            y = SceneManager.GetActiveScene().buildIndex;
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
            instance = this;
        }       
        void Update()
        {
           
            if (pathCreator != null)
            {
                float x;
                if (y == 3)
                {
                    if ((displayParam.instance.start == true && displayParam.instance.Isread ==true ))
                    {
                        bool a = float.TryParse(ReadArduino.instance.data4, out x);
                        if (a == true)
                        {
                            distanceTravelled += float.Parse(ReadArduino.instance.data4) / 10 * Time.deltaTime;
                            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                        }
                    }
                }
                else if (y == 1)
                {
                    if (DisplayParam.instance.start == true && DisplayParam.instance.Isread == true)
                    {
                        bool a = float.TryParse(ReadArduino.instance.data1, out x);
                        if (a == true)
                        {
                            distanceTravelled += float.Parse(ReadArduino.instance.data1) / 10 * Time.deltaTime;
                            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                        }
                    }
                }



            }
        }
        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}