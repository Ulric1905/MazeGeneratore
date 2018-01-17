using System;
using System.Linq;

namespace MazeTP

{
    class Maze
    {
        Random rnd = new Random();
        private int x;
        private int y;
        private int idCase = 0;
        private int depart;
        private int end;
        public int[][] PathTake;
        
        public Case[,] cases { get; private set; }

        public Maze(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.cases = new Case[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    idCase++;
                    cases[i, j] = new Case( idCase, idCase);
                }
            }
        }

        public void getWall()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.WriteLine(cases[i, j].getWallEast());
                    Console.WriteLine(cases[i, j].getWallSouth());
                }
            }
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getFin()
        {
            Console.WriteLine(" end " + end);
            return end;
        }

        public void Fin()
        {
            end = rnd.Next(1, x * y + 1);
        }

        public int getDepart()
        {
            Console.WriteLine(" depart " + depart);
            return depart;
        }

        public void Depart()
        {
            depart = rnd.Next(1, x * y + 1);
        }

        private void ChangementId1(int i, int j)
        {
            cases[i, j + 1].changeId(cases[i, j].getId());
            cases[i, j].DestroyWallEast();
        }

        private void ChangementId2(int i, int j)
        {
            cases[i + 1, j].changeId(cases[i, j].getId());
            cases[i, j].DestroyWallSouth();
        }

        private void ChangementId3(int i, int j)
        {
            cases[i, j - 1].changeId(cases[i, j].getId());
            cases[i, j - 1].DestroyWallEast();
        }

        private void ChangementId4(int i, int j)
        {
            cases[i - 1, j].changeId(cases[i, j].getId());
            cases[i - 1, j].DestroyWallSouth();
        }

        public int getPathfindingX( int indice)
        {
           
            return PathTake[indice][0];
        }
        public int getPathfindingY(int indice)
        {

            return PathTake[indice][1];
        }


        private bool IsAllPrioritySet()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (cases[i, j].getId() == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void pathfinding()
        {
            int ti=0, tj=0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (cases[i, j].getId2() == depart)
                    {
                        cases[i, j].changeId(0);
                    }
                    else
                    {
                        cases[i, j].changeId(-1);
                    }
                    if (cases[i, j].getId2() == end)
                    {
                        ti = i;
                        tj = j;
                    }
                }
            }

            while (!IsAllPrioritySet())
            {
                int min;
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (cases[i, j].getId() == -1)
                        {
                            min = x * y + 1;
                        }
                        else
                        {
                            min = cases[i, j].getId();
                        }

                        if (i != x - 1 && !cases[i, j].getWallSouth())
                        {
                            if (cases[i + 1, j].getId() != -1 && min > cases[i + 1, j].getId() + 1)
                            {
                                min = cases[i + 1, j].getId() + 1;
                            }
                        }
                        if (j != y - 1 && !cases[i, j].getWallEast())
                        {
                            if (cases[i, j + 1].getId() != -1 && min > cases[i, j + 1].getId() + 1)
                            {
                                min = cases[i, j + 1].getId() + 1;
                            }
                        }

                        if (j != 0 && !cases[i, j - 1].getWallEast())
                        {
                            if (cases[i, j - 1].getId() != -1 && min > cases[i, j - 1].getId() + 1)
                            {
                                min = cases[i, j - 1].getId() + 1;
                            }
                        }
                        if (i != 0 && !cases[i - 1, j].getWallSouth())
                        {
                            if (cases[i - 1, j].getId() != -1 && min > cases[i - 1, j].getId() + 1)
                            {
                                min = cases[i - 1, j].getId() + 1;
                            }
                        }

                        if (min == x * y + 1)
                        {
                            cases[i, j].changeId(-1);
                        }
                        else
                        {
                            cases[i, j].changeId(min);
                        }
                    }
                }
            }


            int priorityOfEndCase = cases[ti,tj].getId();
            PathTake = new int[priorityOfEndCase][];
            for (int z = 0; z < priorityOfEndCase; z++)
            {
                PathTake[z] = new int[2];
                PathTake[z] = new[] {-1, -1};
                if (ti != 0 && !cases[ti - 1, tj].getWallSouth() && cases[ti, tj].getId() > cases[ti - 1,tj].getId())
                {
                    PathTake[z][0] = ti;
                    PathTake[z][1] = tj;
                    ti--;
                }
                else if (ti != x - 1 && !cases[ti, tj].getWallSouth() && cases[ti, tj].getId() > cases[ti + 1,tj].getId())
                {
                    PathTake[z][0] = ti;
                    PathTake[z][1] = tj;
                    ti++;
                }
                else if (tj != 0 && !cases[ti, tj - 1].getWallEast() && cases[ti, tj].getId() > cases[ti,tj - 1].getId())
                {
                    PathTake[z][0] = ti;
                    PathTake[z][1] = tj;
                    tj--;
                }
                else if (tj != y - 1 && !cases[ti, tj].getWallEast() && cases[ti, tj].getId() > cases[ti,tj + 1].getId())
                {
                    PathTake[z][0] = ti;
                    PathTake[z][1] = tj;
                    tj++;
                }
            }
            for (int i = 0; i < PathTake.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine("x : " + PathTake[i][0]);
                Console.WriteLine("y : " + PathTake[i][1]);
                Console.WriteLine();
            }
        }


        public void WallGenerator()
        {
           
            int compteur = 0;
            int idCase = 1;
            int[] listNoSouth = new int[y];
            int[] listNoEast = new int[y];
            int[] listNoNorth = new int[x];
            int[] listNoWest = new int[y];
            bool canContinu = true;
            cases[x - 2, y - 1].DestroyWallSouth();
            cases[x - 1, y - 2].DestroyWallEast();
            int[] historique = new int[x * y + 1];
            int compteur2 = 0;


            for (int i = 0; i < y; i++)
            {
                listNoEast[i] = (x * y) - (i * y);
                listNoWest[i] = i * y + 1;
                listNoSouth[i] = (x * y) - i;
            }
            for (int i = 1; i <= listNoNorth.Length; i++)
            {
                listNoNorth[i - 1] = i;
            }

            while (true)
            {
                int compte = 0;
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        /* Si c'est dans un angle */
                        if (cases[i, j].getId() == 1)
                        {
                            compte++;
                        }
                        if (idCase == cases[i, j].getId2())
                        {
                            if (idCase == 1)
                            {
                                int typeWall = rnd.Next(1, 3);
                                if ((typeWall == 1) && (!historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i, j + 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i + 1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i + 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((historique.Contains(cases[i, j + 1].getId2())) &&
                                         (historique.Contains(cases[i + 1, j].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                            }
                            else if (idCase == x)
                            {
                                int typeWall = rnd.Next(1, 3);
                                if ((typeWall == 1) && (!historique.Contains(cases[i + 1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i + 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i, j - 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((historique.Contains(cases[i + 1, j].getId2())) &&
                                         (historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                                else if (canContinu == false)
                                {
                                    if (!historique.Contains(cases[i, j - 1].getId2()))
                                    {
                                        ChangementId3(i, j);
                                    }
                                }
                            }
                            else if (idCase == (x * y) - x + 1)
                            {
                                int typeWall = rnd.Next(1, 3);
                                if ((typeWall == 1) && (!historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i, j + 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i - 1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i - 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((historique.Contains(cases[i, j + 1].getId2())) &&
                                         (historique.Contains(cases[i - 1, j].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                            }
                            else if (idCase == x * y)
                            {
                                int typeWall = rnd.Next(3, 5);
                                if ((typeWall == 3) && (!historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i, j - 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 4) && (!historique.Contains(cases[i - 1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i - 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((historique.Contains(cases[i, j - 1].getId2())) &&
                                         (historique.Contains(cases[i - 1, j].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                            }
                            /* Si c'est dans un cote */
                            else if (listNoEast.Contains(idCase))
                            {
                                int typeWall = rnd.Next(1, 4);
                                if ((typeWall == 1) && (!historique.Contains(cases[i + 1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i + 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i, j - 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 3) && (!historique.Contains(cases[i - 1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i - 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if (canContinu == false)
                                {
                                    if (!historique.Contains(cases[i, j - 1].getId2()))
                                    {
                                        ChangementId3(i, j);
                                    }
                                    if (!historique.Contains(cases[i + 1, j].getId2()))
                                    {
                                        ChangementId2(i, j);
                                    }
                                    if (!historique.Contains(cases[i - 1, j].getId2()))
                                    {
                                        ChangementId4(i, j);
                                    }
                                }
                                else if ((historique.Contains(cases[i + 1, j].getId2())) &&
                                         (historique.Contains(cases[i - 1, j].getId2())) &&
                                         (historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                            }
                            else if (listNoSouth.Contains(idCase))
                            {
                                int typeWall = rnd.Next(1, 4);
                                if ((typeWall == 1) && (!historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i, j + 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i, j - 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 3) && (!historique.Contains(cases[i - 1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i - 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if (canContinu == false)
                                {
                                    if (!historique.Contains(cases[i, j - 1].getId2()))
                                    {
                                        ChangementId3(i, j);
                                    }
                                    if (!historique.Contains(cases[i, j + 1].getId2()))
                                    {
                                        ChangementId1(i, j);
                                    }
                                    if (!historique.Contains(cases[i - 1, j].getId2()))
                                    {
                                        ChangementId4(i, j);
                                    }
                                }
                                else if ((historique.Contains(cases[i, j + 1].getId2())) &&
                                         (historique.Contains(cases[i - 1, j].getId2())) &&
                                         (historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                            }
                            else if (listNoWest.Contains(idCase))
                            {
                                historique[compteur] = idCase;
                                int typeWall = rnd.Next(1, 4);
                                if ((typeWall == 1) && (!historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i, j + 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i + 1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i + 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 3) && (!historique.Contains(cases[i - 1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i - 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if (canContinu == false)
                                {
                                    if (!historique.Contains(cases[i + 1, j].getId2()))
                                    {
                                        ChangementId2(i, j);
                                    }
                                    if (!historique.Contains(cases[i, j + 1].getId2()))
                                    {
                                        ChangementId1(i, j);
                                    }
                                    if (!historique.Contains(cases[i - 1, j].getId2()))
                                    {
                                        ChangementId4(i, j);
                                    }
                                }
                                else if ((historique.Contains(cases[i, j + 1].getId2())) &&
                                         (historique.Contains(cases[i - 1, j].getId2())) &&
                                         (historique.Contains(cases[i + 1, j].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                            }
                            else if (listNoNorth.Contains(idCase))
                            {
                                int typeWall = rnd.Next(1, 4);
                                if ((typeWall == 1) && (!historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i, j + 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i + 1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i + 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 3) && (!historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i, j - 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if (canContinu == false)
                                {
                                    if (!historique.Contains(cases[i, j - 1].getId2()))
                                    {
                                        ChangementId3(i, j);
                                    }
                                    if (!historique.Contains(cases[i + 1, j].getId2()))
                                    {
                                        ChangementId2(i, j);
                                    }
                                    if (!historique.Contains(cases[i, j + 1].getId2()))
                                    {
                                        ChangementId1(i, j);
                                    }
                                }
                                else if ((historique.Contains(cases[i + 1, j].getId2())) &&
                                         (historique.Contains(cases[i, j - 1].getId2())) &&
                                         (historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                            }
                            /* sinon */
                            else
                            {
                                int typeWall = rnd.Next(1, 5);
                                if ((typeWall == 1) && (!historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i, j + 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i + 1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i + 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 3) && (!historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i, j - 1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 4) && (!historique.Contains(cases[i - 1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i - 1, j].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if (canContinu == false)
                                {
                                    if (!historique.Contains(cases[i, j - 1].getId2()))
                                    {
                                        ChangementId3(i, j);
                                    }
                                    if (!historique.Contains(cases[i + 1, j].getId2()))
                                    {
                                        ChangementId2(i, j);
                                    }
                                    if (!historique.Contains(cases[i, j + 1].getId2()))
                                    {
                                        ChangementId1(i, j);
                                    }
                                    if (!historique.Contains(cases[i - 1, j].getId2()))
                                    {
                                        ChangementId4(i, j);
                                    }
                                }
                                else if ((historique.Contains(cases[i + 1, j].getId2())) &&
                                         (historique.Contains(cases[i - 1, j].getId2())) &&
                                         (historique.Contains(cases[i, j - 1].getId2())) &&
                                         (historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("loading");
                if (compte == (x * y))
                {
                    break;
                }
                if (canContinu == false)
                {
                    idCase = historique[compteur2];
                    compteur2++;
                    canContinu = true;
                }
            }
            for (int i = 0; i < historique.Length; i++)
            {
                Console.WriteLine(historique[i]);
            }
        }
    }

    public class Case
    {
        private int id;
        private int id2;
        private bool wallEast;
        private bool wallSouth;


        public Case(int id, int id2)
        {
 
            this.id = id;
            this.id2 = id2;
            wallEast = true;
            wallSouth = true;
        }

        public void changeId(int idCp)
        {
            id = idCp;
        }

        public void DestroyWallEast()
        {
            wallEast = false;
        }

        public void DestroyWallSouth()
        {
            wallSouth = false;
        }

        public int getId()
        {
            return id;
        }

        public bool getWallEast()
        {
            return wallEast;
        }

        public bool getWallSouth()
        {
            return wallSouth;
        }

        public int getId2()
        {
            return id2;
        }


       
    }
}