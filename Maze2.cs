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
        Random rnd = new Random();
        private int x;
        private int y;
        private int idCase = 0;
        private int depart;
        private int end;
        int[] listToReturn;
        int n = 1;
        int compteur = 0;
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
            cases[i -1 , j].DestroyWallSouth();
            
        }
        public int[] getPathfinding()
        {
            for (int i =0; i < listToReturn.Length; i++)
            {
                Console.WriteLine(listToReturn[i]);
            }
            return listToReturn;
        }
        public void pathfinding()
        {
            int nbcase;

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
                        cases[i, j].changeId(x * y);
                    }
                }
            }
            int compte = 0;
            int p = 1;
            while (p == 1)
            {
                for (int a = 0; a < x; a++)
                {
                    for (int b = 0; b < y; b++)
                    {
                        if (cases[a, b].getId2() == end)
                        {
                            if (cases[a, b].getId() == compte)
                            {
                                p = 2;
                            }
                        }
                        if (cases[a, b].getId() == compte)
                        {
                            if (a == 0)
                            {
                                if (b == 0)
                                {
                                    if ((cases[a, b].getWallEast() == false) && (cases[a,b +1].getId() > compte ))
                                    {
                                        cases[a, b + 1].changeId(compte + 1);
                                    }
                                    if ((cases[a, b].getWallSouth() == false) && (cases[a +1, b ].getId() > compte  ))
                                    {
                                        cases[a + 1, b].changeId(compte + 1);
                                    }
                                }
                                else if (b == y- 1)
                                {
                                    if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b -1].getId() > compte ))
                                    {
                                        cases[a, b - 1].changeId(compte + 1);
                                    }
                                    if ((cases[a, b].getWallSouth() == false) && (cases[a +1, b].getId() > compte ))
                                    {
                                        cases[a + 1, b].changeId(compte + 1);
                                    }
                                }
                                else
                                {
                                    if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b -1].getId() > compte ))
                                    {
                                        cases[a, b - 1].changeId(compte + 1);
                                    }
                                    if ((cases[a, b].getWallSouth() == false) && (cases[a +1, b].getId() > compte ))
                                    {
                                        cases[a + 1, b].changeId(compte + 1);
                                    }
                                    if ((cases[a, b +1].getWallEast() == false) && (cases[a, b].getId() > compte ))
                                    {
                                        cases[a, b + 1].changeId(compte + 1);
                                    }
                                }
                            }
                            else if (a == x - 1)
                            {
                                if (b == 0)
                                {
                                    if ((cases[a, b].getWallEast() == false) && (cases[a, b +1].getId() > compte ))
                                    {
                                        cases[a, b + 1].changeId(compte + 1);
                                    }
                                    if ((cases[a - 1, b].getWallSouth() == false) && (cases[a -1, b].getId() >compte  ))
                                    {
                                        cases[a - 1, b].changeId(compte + 1);
                                    }
                                }
                                else if (b == x -1)
                                {
                                    if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b -1].getId() > compte ))
                                    {
                                        cases[a, b - 1].changeId(compte + 1);
                                    }
                                    if ((cases[a - 1, b].getWallSouth() == false) && (cases[a -1, b].getId() > compte ))
                                    {
                                        cases[a - 1, b].changeId(compte + 1);
                                    }
                                }
                                else
                                {
                                    if ((cases[a, b - 1].getWallEast() == false)&& (cases[a , b -1].getId() > compte))
                                    {
                                        cases[a, b - 1].changeId(compte + 1);
                                    }
                                    if ((cases[a - 1, b].getWallSouth() == false) && (cases[a - 1, b].getId() > compte))
                                    {
                                        cases[a - 1, b].changeId(compte + 1);
                                    }
                                    if ((cases[a, b].getWallEast() == false) && (cases[a , b+1].getId() > compte))
                                    {
                                        cases[a, b + 1].changeId(compte + 1);
                                    }
                                }

                            }
                            else if (b == 0)
                            {
                                if ((cases[a, b].getWallSouth() == false && (cases[a +1, b].getId() > compte)))
                                {
                                    cases[a + 1, b].changeId(compte + 1);
                                }
                                if ((cases[a - 1, b].getWallSouth() == false) && (cases[a -1, b].getId() > compte))
                                {
                                    cases[a - 1, b].changeId(compte + 1);
                                }
                                if ((cases[a, b].getWallEast() == false)&& (cases[a, b + 1].getId() > compte))
                                {
                                    cases[a, b + 1].changeId(compte + 1);
                                }
                            }
                            else if (b == y - 1)
                            {
                                if ((cases[a, b].getWallSouth() == false) && (cases[a +1, b ].getId() > compte))
                                {
                                    cases[a + 1, b].changeId(compte + 1);
                                }
                                if ((cases[a - 1, b].getWallSouth() == false) && (cases[a -1, b ].getId() > compte))
                                {
                                    cases[a - 1, b].changeId(compte + 1);
                                }
                                if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b - 1].getId() > compte))
                                {
                                    cases[a, b - 1].changeId(compte + 1);
                                }
                            }
                            else
                            {
                                if ((cases[a, b].getWallSouth() == false) && (cases[a +1, b].getId() > compte))
                                {
                                    cases[a + 1, b].changeId(compte + 1);
                                }
                                if ((cases[a - 1, b].getWallSouth() == false)&& (cases[a -1, b ].getId() > compte))
                                {
                                    cases[a - 1, b].changeId(compte + 1);
                                }
                                if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b - 1].getId() > compte))
                                {
                                    cases[a, b - 1].changeId(compte + 1);
                                }
                                if ((cases[a, b].getWallEast() == false)&& (cases[a, b + 1].getId() > compte))
                                {
                                    cases[a, b + 1].changeId(compte + 1);
                                }
                            }
                        }
                        



                    }
                }
                compte++;
            }
            for(int a = 0; a < x; a++)
            {
                for (int b = 0; b < y; b++)
                {
                    Console.WriteLine("idCase :" + cases[a, b].getId());
                    if (cases[a,b].getId2() == end)
                    {
                        nbcase = cases[a, b].getId();
                        listToReturn = new int[nbcase];
                    }
                }
            }
            nbcase = listToReturn.Length ;
            Console.WriteLine("nbcase" + nbcase);
            int lastId = nbcase -1 ;
            int compte2 = 0;
            int w = 1;
            listToReturn[0] = end;
            
           
            while (w == 1)
            {
                for (int a = 0; a < x; a++)
                {
                    for (int b = 0; b < y; b++)
                    {
                        if (compte2 == listToReturn.Length-1)
                        {
                            w = 2;
                        }
                        else if ((cases[a, b].getId() == listToReturn[compte2]) || (nbcase == listToReturn.Length))
                        {
                            if (a == 0)
                            {
                                if (b == 0)
                                {
                                    if ((cases[a, b].getWallEast() == false) && (cases[a, b + 1].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a, b + 1].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                    else if ((cases[a, b].getWallSouth() == false) && (cases[a + 1, b].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a + 1, b].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                }
                                else if (b == y - 1)
                                {
                                    if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b - 1].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a, b - 1].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                    else if ((cases[a, b].getWallSouth() == false) && (cases[a + 1, b].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a + 1, b].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                }
                                else
                                {
                                    if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b - 1].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a, b - 1].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                    else if ((cases[a, b].getWallSouth() == false) && (cases[a + 1, b].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a + 1, b].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                    else if ((cases[a, b + 1].getWallEast() == false) && (cases[a, b].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a, b + 1].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                }
                            }
                            else if (a == x - 1)
                            {
                                if (b == 0)
                                {
                                    if ((cases[a, b].getWallEast() == false) && (cases[a, b + 1].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a, b + 1].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                    else if ((cases[a - 1, b].getWallSouth() == false) && (cases[a - 1, b].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a - 1, b].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                }
                                else if (b == x - 1)
                                {
                                    if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b - 1].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a, b - 1].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                    else if ((cases[a - 1, b].getWallSouth() == false) && (cases[a - 1, b].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a - 1, b].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                }
                                else
                                {
                                    if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b - 1].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a, b - 1].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                    else if ((cases[a - 1, b].getWallSouth() == false) && (cases[a - 1, b].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a - 1, b].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                    else if ((cases[a, b].getWallEast() == false) && (cases[a, b + 1].getId() == (lastId)))
                                    {
                                        listToReturn[compte2 + 1] = cases[a, b + 1].getId2();
                                        nbcase--;
                                        compte2++;
                                        lastId--;
                                    }
                                }

                            }
                            else if (b == 0)
                            {
                                if ((cases[a, b].getWallSouth() == false) && (cases[a + 1, b].getId() == (lastId)))
                                {
                                    listToReturn[compte2 + 1] = cases[a + 1, b].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                                else if ((cases[a - 1, b].getWallSouth() == false) && (cases[a - 1, b].getId() == (lastId)))
                                {
                                    listToReturn[compte2 + 1] = cases[a - 1, b].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                                else if ((cases[a, b].getWallEast() == false) && (cases[a, b + 1].getId() == (lastId)))
                                {
                                    listToReturn[compte2 + 1] = cases[a, b + 1].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                            }
                            else if (b == y - 1)
                            {
                                if ((cases[a, b].getWallSouth() == false) && (cases[a + 1, b].getId() == (lastId)))
                                {
                                    listToReturn[compte2 + 1] = cases[a + 1, b].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                                else if ((cases[a - 1, b].getWallSouth() == false) && (cases[a - 1, b].getId() == (lastId)))
                                {
                                    listToReturn[compte2 + 1] = cases[a - 1, b].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                                else if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b - 1].getId() == (lastId)))
                                {
                                    listToReturn[compte2 + 1] = cases[a, b - 1].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                            }
                            else
                            {
                                if ((cases[a, b].getWallSouth() == false) && (cases[a + 1, b].getId() == (lastId)))
                                {
                                    listToReturn[compte2 + 1] = cases[a + 1, b].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                                else if ((cases[a - 1, b].getWallSouth() == false) && (cases[a - 1, b].getId() == (lastId)))
                                {
                                    listToReturn[compte2 + 1] = cases[a - 1, b].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                                else if ((cases[a, b - 1].getWallEast() == false) && (cases[a, b - 1].getId() == (lastId)))
                                {
                                    listToReturn[compte2 + 1] = cases[a, b - 1].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                                else if ((cases[a, b].getWallEast() == false) && (cases[a, b + 1].getId() == (lastId)))
                                {
                                    listToReturn[compte2] = cases[a, b + 1].getId2();
                                    nbcase--;
                                    compte2++;
                                    lastId--;
                                }
                            }
                        }
                    }
                }
                
            }
            for (int a = 0; a < listToReturn.Length; a++)
            {
                Console.WriteLine(listToReturn[a]);
            }
            
        }












        public void WallGenerator()
        {
            
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
                listNoNorth[i-1] = i;
            }
           
            while ( true )
            {
                int compte = 0;
                for (int i=0; i<x; i++)
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
                                if ((typeWall == 1) && ( !historique.Contains(cases[i,j +1 ].getId2())))
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i, j+1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;

                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i +1, j ].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((historique.Contains(cases[i,j +1].getId2())) && (historique.Contains(cases[i + 1, j].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                                

                            }
                            else if (idCase == x) 
                            {
                                
                                int typeWall = rnd.Next(1, 3);
                                if( (typeWall == 1) && (!historique.Contains(cases[i +1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i , j -1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((historique.Contains(cases[i +1, j ].getId2())) && (historique.Contains(cases[i, j -1].getId2())))
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
                            else if (idCase == (x*y)-x+1)
                            {
                                
                                int typeWall = rnd.Next(1, 3);
                                if ((typeWall == 1) && (!historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    ChangementId1(i, j);
                                    idCase = cases[i , j +1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i -1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i -1, j ].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((historique.Contains(cases[i, j + 1].getId2())) && (historique.Contains(cases[i - 1, j].getId2())))
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
                                    idCase = cases[i , j -1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 4) && (!historique.Contains(cases[i -1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[ i -1, j ].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((historique.Contains(cases[i, j- 1].getId2())) && (historique.Contains(cases[i - 1, j].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }
                            }
                            /* Si c'est dans un cote */
                            else if (listNoEast.Contains(idCase))
                            {
                               
                                int typeWall = rnd.Next(1, 4);
                                if ((typeWall == 1) && (!historique.Contains(cases[i +1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i , j -1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 3 ) && (!historique.Contains(cases[i -1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i -1 , j ].getId2();
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
                                else if ((historique.Contains(cases[i +1, j ].getId2())) && (historique.Contains(cases[i - 1, j].getId2())) && (historique.Contains(cases[i,j -1].getId2())))
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
                                else if ((historique.Contains(cases[i, j + 1].getId2())) && (historique.Contains(cases[i - 1, j].getId2())) && (historique.Contains(cases[i, j - 1].getId2())))
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
                                    idCase = cases[i , j +1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;

                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i +1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 3) && (!historique.Contains(cases[i -1, j].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i -1, j ].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if (canContinu == false)
                                {
                                    if (!historique.Contains(cases[i +1, j ].getId2()))
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
                                else if ((historique.Contains(cases[i , j+1].getId2())) && (historique.Contains(cases[i - 1, j].getId2())) && (historique.Contains(cases[i +1, j ].getId2())))
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
                                    idCase = cases[i , j+1].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 2) && (!historique.Contains(cases[i +1, j].getId2())))
                                {
                                    ChangementId2(i, j);
                                    idCase = cases[i +1, j ].getId2();
                                    historique[compteur] = idCase;
                                    compteur++;
                                }
                                else if ((typeWall == 3) && (!historique.Contains(cases[i, j - 1].getId2())))
                                {
                                    ChangementId3(i, j);
                                    idCase = cases[i , j-1 ].getId2();
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
                                    if (!historique.Contains(cases[i , j +1].getId2()))
                                    {
                                        ChangementId1(i, j );
                                    }

                                }
                                else if ((historique.Contains(cases[i + 1, j].getId2())) && (historique.Contains(cases[i , j -1].getId2())) && (historique.Contains(cases[i, j + 1].getId2())))
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
                                else if ((typeWall == 2) && (!historique.Contains(cases[i +1, j ].getId2())))
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
                                else if ((typeWall == 4) && (!historique.Contains(cases[i -1, j ].getId2())))
                                {
                                    ChangementId4(i, j);
                                    idCase = cases[i -1, j ].getId2();
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
                                    if (!historique.Contains(cases[i -1, j ].getId2()))
                                    {
                                        ChangementId4(i, j);
                                    }


                                }
                                else if ((historique.Contains(cases[i + 1, j].getId2())) && (historique.Contains(cases[i - 1, j].getId2())) && (historique.Contains(cases[i, j - 1].getId2())) && (historique.Contains(cases[i, j + 1].getId2())))
                                {
                                    canContinu = false;
                                    break;
                                }


                            }
                            

                        }
                    }
                    
                }
                Console.WriteLine("loading");
                if (compte == (x * y ))
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
