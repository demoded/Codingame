using System;

namespace Puzzle011detectivePikaptcha2
{
    public class Program
    {
        public static class DirectionIndex
        {
            public static readonly int Right = 0;
            public static readonly int Down = 1;
            public static readonly int Left = 2;
            public static readonly int Up = 3;
        };

        static (int, int)[] directions = new (int, int)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
        static int playerStartDirection = 0;
        static int playerDirection = 0;
        static int playerFollowWall = 0;
        static int playerFollowWallDirection = 0;

        public static void Main(string[] args)
        {
            (int, int) startPosition = (0,0);
            (int, int) playerPosition = (0,0);

            string firstline = Console.ReadLine();
            Console.Error.WriteLine(firstline);
            string[] inputs = firstline.Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            char[][] map = new char[height][];

            //read map
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine();
                map[i] = line.ToCharArray();
                Console.Error.WriteLine(line);

                var inputPosition = line.IndexOfAny("<>v^".ToCharArray());
                if (inputPosition >= 0)
                {
                    playerPosition = (i, inputPosition);
                    startPosition = playerPosition;
                    Console.Error.WriteLine($"position {playerPosition}");
                    playerStartDirection = CharToDirection(line[inputPosition]);
                    playerDirection = playerStartDirection;
                    map[i][inputPosition] = '0';
                }
            }
            string inputFollowWall = Console.ReadLine();
            playerFollowWall = CharToDirection(inputFollowWall[0]);
            playerFollowWallDirection = TurnPlayerTo(playerFollowWall, playerDirection);
            Console.Error.WriteLine(inputFollowWall);
            var nextPosition = playerPosition;
            //solve
            do
            {
                if (playerPosition == nextPosition)
                {
                    if (IsFollowingWall(map, playerPosition))
                    {
                        nextPosition = (playerPosition.Item1 + directions[playerDirection].Item1,
                                        playerPosition.Item2 + directions[playerDirection].Item2);

                        if (IsWallPosition(map, nextPosition))
                        {
                            //turn to opposete following wall direction
                            playerDirection = TurnPlayerTo(OppositeDirection(playerFollowWall), playerDirection);
                            playerFollowWallDirection = TurnPlayerTo(playerFollowWall, playerDirection);
                            nextPosition = playerPosition;

                            //check if trapped
                            if (playerDirection == playerStartDirection && map[startPosition.Item1][startPosition.Item2] == '0')
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        //turn to following wall direction
                        playerDirection = TurnPlayerTo(playerFollowWall, playerDirection);
                        playerFollowWallDirection = TurnPlayerTo(playerFollowWall, playerDirection);
                        nextPosition = (playerPosition.Item1 + directions[playerDirection].Item1,
                                        playerPosition.Item2 + directions[playerDirection].Item2);
                    }
                }
                else
                {
                    StepInto(playerPosition, map);
                    playerPosition = nextPosition; 
                }
            }
            while (playerPosition != startPosition || map[startPosition.Item1][startPosition.Item2] == '0');

            //print map
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(new string(map[i]));
            }
        }

        private static int OppositeDirection(int playerFollowWall)
        {
            return (playerFollowWall + 2) % 4;
        }

        private static int TurnPlayerTo(int turnDirection, int playerDirection)
        {
            if (turnDirection == DirectionIndex.Left)
            { 
                // Left wall
                return (playerDirection + 3) % 4;
            }
            else if (turnDirection == DirectionIndex.Right)
            {
                // Right wall
                return (playerDirection + 1) % 4;
            }

            return playerDirection;
        }

        private static bool IsFollowingWall(char[][] map, (int, int) playerPosition)
        {
            var lookForWallAtPosition = (playerPosition.Item1 + directions[playerFollowWallDirection].Item1,
                    playerPosition.Item2 + directions[playerFollowWallDirection].Item2);

            if(IsWallPosition(map, lookForWallAtPosition))
            {
                return true;
            }

            return false;
        }

        private static bool IsWallPosition(char[][] map, (int, int) testPosition)
        {
            if (testPosition.Item1 < 0 || testPosition.Item1 >= map.Length ||
                testPosition.Item2 < 0 || testPosition.Item2 >= map[0].Length ||
                map[testPosition.Item1][testPosition.Item2] == '#')
            {
                return true;
            }

            return false;
        }

        private static void StepInto((int, int) playerPosition, char[][] map)
        {
            map[playerPosition.Item1][playerPosition.Item2]++;// = '0';
        }

        private static int CharToDirection(char inputChar)
        {
            switch (inputChar)
            {
                case '>': return DirectionIndex.Right;
                case 'v': return DirectionIndex.Down;
                case '<': return DirectionIndex.Left;
                case '^': return DirectionIndex.Up;
                case 'R': return DirectionIndex.Right;
                case 'L': return DirectionIndex.Left;
                default:
                    throw new Exception("Invalid direction");
            }
        }
    }
}
