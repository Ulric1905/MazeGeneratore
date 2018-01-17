using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MazeTP

{

    class Maze
    {
        private int x;
        private int y;
        private int idCase = 0;
        int n = 1;
        public Case[,] cases { get; private set; }
        public Maze(int x, int y)
        {

            this.x = x;
            this.y = y;
            this.cases = new Case[x, y];
            for (int i=0; i< x; i++)
            {
                for (int j =0; j < y; j++)
                {
                    idCase++;
                    cases[i, j] = new Case(x, y, idCase, idCase);
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
        public void ChangementId1(int i,int j)
        {
            
            cases[i , j + 1].changeId(cases[i, j].getId());
            cases[i, j].DestroyWallEast();
        }
        public void ChangementId2(int i, int j)
        {
            
            cases[i +1, j].changeId(cases[i, j].getId());
            cases[i, j].DestroyWallSouth();
        }
        public void ChangementId3(int i, int j)
        {
            
            cases[i , j -1].changeId(cases[i, j].getId());
            cases[i , j -1].DestroyWallEast();
        }
        public void ChangementId4(int i, int j)
        {
            
            cases[i -1 , j ].changeId(cases[i, j].getId());
            cases[i -1 , j].DestroyWallEast();
        }
        public void test()
        {
            for(int i =0; i< y; i++)
            {
                Console.Write(cases[i, 0].getId());
            }
        }
        public void WallGenerator()
        {
            Random rnd = new Random();
            int idCase = 1;
            int[] listNoSouth = new int[y];
            int[] listNoEast = new int[y];
            int[] listNoNorth = new int[x];
            int[] listNoWest = new int[y];
            
            for (int i = 0; i < y; i++)
            {
                listNoEast[i] = (x * y) - (i * y);
                listNoWest[i] = i * y + 1;
                listNoSouth[i] = (x * y) - i;
            }
            for (int i = 1; i <= listNoNorth.Length; i++)
            {
                listNoNorth[i-1] = i;
            }
           
            while ( true )
            {
                int compte = 0;
                for (int i=0; i<x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (cases[i, j].getId() == 1)
                        {
                            compte++;
                        }
                        if (idCase == cases[i, j].getId2())
                        {
                            if (idCase == 1)
                            {
                                int typeWall = rnd.Next(1, 3);
                                if (typeWall == 1)
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i, j+1].getId2();
                                }
                                else if (typeWall == 2)
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                }
                            }
                            else if (idCase == x)
                            {
                                int typeWall = rnd.Next(2, 4);
                                if (typeWall == 2)
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                }
                                else if (typeWall == 3)
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i , j -1].getId2();
                                }
                            }
                            else if (idCase == (x*y)-x)
                            {
                                int typeWall = rnd.Next(1, 3);
                                if (typeWall == 1)
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i , j +1].getId2();
                                }
                                else if (typeWall == 2)
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i -1, j ].getId2();
                                }
                            }
                            else if (idCase == x * y)
                            {
                                int typeWall = rnd.Next(3, 5);
                                if (typeWall == 3)
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i , j -1].getId2();
                                }
                                else if (typeWall == 4)
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[ i +1, j ].getId2();
                                }
                            }
                            else if (listNoEast.Contains(idCase))
                            {
                                int typeWall = rnd.Next(2, 5);
                                if (typeWall == 2)
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                }
                                else if (typeWall == 3)
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i , j -1].getId2();
                                }
                                else if (typeWall == 4)
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i -1 , j ].getId2();
                                }
                            }
                            else if (listNoSouth.Contains(idCase))
                            {
                                int typeWall = rnd.Next(1, 4);
                                if (typeWall == 1)
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i , j +1].getId2();
                                }
                                else if (typeWall == 2)
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i , j -1 ].getId2();
                                }
                                else if(typeWall == 3)
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i -1, j].getId2();
                                }
                            } 
                            else if (listNoWest.Contains(idCase))
                            {
                                int typeWall = rnd.Next(1, 4);
                                if (typeWall == 1)
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i , j +1].getId2();
                                }
                                else if (typeWall == 2)
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                }
                                else if (typeWall == 3)
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i -1, j ].getId2();
                                }

                            }
                            else if (listNoNorth.Contains(idCase))
                            {
                                int typeWall = rnd.Next(1, 4);
                                if (typeWall == 1)
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i , j+1].getId2();
                                }
                                else if (typeWall == 2)
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                }
                                else if (typeWall == 3)
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i , j-1 ].getId2();
                                }
                            }
                            else
                            {
                                for(int a=0; a< listNoEast.Length; a++)
                                {
                                    if( idCase == listNoEast[a])
                                    {
                                        int typeWall2 = rnd.Next(2, 5);
                                        if (typeWall2 == 2)
                                        {
                                            ChangementId2(i, j);
                                            idCase = cases[i, j + 1].getId2();
                                        }
                                        else if (typeWall2 == 3)
                                        {
                                            ChangementId3(i, j);
                                            idCase = cases[i, j - 1].getId2();
                                        }
                                        else if (typeWall2 == 4)
                                        {
                                            ChangementId4(i, j);
                                            idCase = cases[i, j - 1].getId2();
                                        }
                                    }
                                    else if (idCase == listNoSouth[a])
                                    {
                                        int typeWall2 = rnd.Next(1, 4);
                                        if (typeWall2 == 1)
                                        {
                                            ChangementId1(i, j);
                                            idCase = cases[i , j + 1].getId2();
                                        }
                                        else if (typeWall2 == 2)
                                        {
                                            ChangementId3(i, j);
                                            idCase = cases[i , j - 1].getId2();
                                        }
                                        else if (typeWall2 == 3)
                                        {
                                            ChangementId4(i, j);
                                            idCase = cases[i , j - 1].getId2();
                                        }
                                    }
                                    else if (idCase == listNoWest[a])
                                    {
                                        int typeWall2 = rnd.Next(1, 4);
                                        if (typeWall2 == 1)
                                        {
                                            ChangementId1(i, j);
                                            idCase = cases[i , j + 1].getId2();
                                        }
                                        else if (typeWall2 == 2)
                                        {
                                            ChangementId2(i, j);
                                            idCase = cases[i + 1, j ].getId2();
                                        }
                                        else if (typeWall2 == 3)
                                        {
                                            ChangementId4(i, j);
                                            idCase = cases[i , j - 1].getId2();
                                        }
                                    }
                                    else if  (idCase == listNoNorth[a])
                                    {
                                        int typeWall2 = rnd.Next(1, 4);
                                        if (typeWall2 == 1)
                                        {
                                            ChangementId1(i, j);
                                            idCase = cases[i, j + 1].getId2();
                                        }
                                        else if (typeWall2 == 2)
                                        {
                                            ChangementId3(i, j);
                                            idCase = cases[i , j - 1].getId2();
                                        }
                                        else if (typeWall2 == 3)
                                        {
                                            ChangementId4(i, j);
                                            idCase = cases[i , j - 1].getId2();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("merde");
                                        int typeWall = rnd.Next(1, 5);
                                        if (typeWall == 1)
                                        {
                                            ChangementId1(i, j);
                                            idCase = cases[i , j +1].getId2();
                                        }
                                        else if (typeWall == 2)
                                        {
                                            ChangementId2(i, j);
                                            idCase = cases[i + 1, j].getId2();
                                        }
                                        else if (typeWall == 3)
                                        {
                                            ChangementId3(i, j);
                                            idCase = cases[i , j -1].getId2();
                                        }
                                        else if (typeWall == 4)
                                        {
                                            ChangementId4(i, j);
                                            idCase = cases[i , j - 1].getId2();
                                        }
                                    }
                                }
                               
                                
                            }
                            

                        }
                    }

                }
                

                if(compte == (x * y))
                {
                    break;
                }
                Console.WriteLine(idCase);
                Console.ReadLine();
            }
        }





    }
    public class Case
    {
        private int cooX;
        private int cooY;
        public int id;
        private int id2;
        public bool wallEast;
        public bool wallSouth;


        public Case(int cooX, int cooY, int id, int id2)
        {
            this.cooX = cooX;
            this.cooY = cooY;
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
        

        protected int Id { get => id; set => id = value; }
    }
}
