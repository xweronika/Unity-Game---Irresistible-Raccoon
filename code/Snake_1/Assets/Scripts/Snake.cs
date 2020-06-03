using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class Snake : MonoBehaviour
{
    // kierunki w ktore moze podazac waz
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    private enum State
    {
        Alive,
        Dead
    }
    public float volume = 1f; // dzwiek
    private State state;
    private Direction gridMoveDirection;
    private Vector2Int gridPosition;
    // aby pozycja siatki zmieniala sie automatycznie:
    private float gridMoveTimer; // timer przesuniecia siatki
    private float gridMoveTimerMax; // bedzie zawierac czas miedzy ruchami
    private LevelGrid levelGrid; // wlasna lokalna siatka
    public GameObject score;
    private int snakeBodySize; // przechowuje rozmiar ciala weza
    private List<SnakeMovePosition> snakeMovePositionList;
    private List<SnakeBodyPart> snakeBodyPartList;
    private int hp;
    private System.Random rng = new System.Random();
    private bool refresh = false;
    private bool collision;
    private bool foodMove = false;

    public void Setup(LevelGrid levelGrid) // funkcja konfiguracji weza
    {
        this.levelGrid = levelGrid;
    }

    private void Awake()
    {
        SoundManager.PlaySoundBackground(SoundManager.Sound.BackgroundSound, volume); // funkcja odtwarzjaca dzwiek

        gridPosition = new Vector2Int(10, 10); // budzi sie na srodku siatki
        gridMoveTimerMax = .19f; // waz bedzie ruszal co sekunde, predkosc weza
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = Direction.Right;

        snakeMovePositionList = new List<SnakeMovePosition>();
        snakeBodySize = 0;// ustawiamy dl weza 
        snakeBodyPartList = new List<SnakeBodyPart>();
        state = State.Alive; // po otworzeniu gry waz bedzie mial status zywy
        hp = 5;
    }
    private void Update() // zeby poprawnie pozycjonowac weza
    {
        SoundManager.PlayBackground(SoundManager.Sound.BackgroundSound); // funkcja do muzyki w tle

        switch (state) {
            case State.Alive:
                HandleInput();
                HandleGridMovement();
                break;
            case State.Dead:
                break;
        }
    }

    private void HandleInput() // sterowanie wezem
    {
        var dir = gridMoveDirection;
        if (Input.GetKeyDown(KeyCode.UpArrow) && refresh == true) // jesli klikniemy strzalke w gore
        {
            if (gridMoveDirection != Direction.Down && gridMoveDirection != Direction.Up)
            {
                refresh = false;
                // zeby waz poruszal sie zgodnie 
                // np zeby po ruchu w gore, nie mozna bylo w dol
                gridMoveDirection = Direction.Up;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && refresh == true)
        {
            if (gridMoveDirection != Direction.Up && gridMoveDirection != Direction.Down)
            {
                refresh = false;
                gridMoveDirection = Direction.Down;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && refresh == true)
        {
            if (gridMoveDirection != Direction.Right && gridMoveDirection != Direction.Left)
            {
                refresh = false;
                gridMoveDirection = Direction.Left;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && refresh == true)
        {
            if (gridMoveDirection != Direction.Left && gridMoveDirection != Direction.Right)
            {
                refresh = false;
                gridMoveDirection = Direction.Right;
            }
        }

        Vector2Int gridMoveDirectionVector;
        switch (gridMoveDirection)
        {
            default:
            case Direction.Right:
                gridMoveDirectionVector = new Vector2Int(+1, 0); break;
            case Direction.Left:
                gridMoveDirectionVector = new Vector2Int(-1, 0); break;
            case Direction.Up:
                gridMoveDirectionVector = new Vector2Int(0, +1); break;
            case Direction.Down:
                gridMoveDirectionVector = new Vector2Int(0, -1); break;
        }
        if (levelGrid.obstacles.Contains(gridPosition + gridMoveDirectionVector))
        {
            gridMoveDirection = dir;
        }
    }
    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        // zwiekszenie czasu przesuniecia siatki o czas oczekiwania
        if (gridMoveTimer >= gridMoveTimerMax)
        {

            gameObject.GetComponent<Animator>().speed = 1.0f;
            gameObject.GetComponent<Animator>().Update(0.0f);
            gameObject.GetComponent<Animator>().Update(0.5f);
            gameObject.GetComponent<Animator>().speed = 0.0f;
            foreach (SnakeBodyPart p in snakeBodyPartList)
            {
                p.snakeBodyGameObject.GetComponent<Animator>().speed = 1.0f;
                p.snakeBodyGameObject.GetComponent<Animator>().Update(0.0f);
                p.snakeBodyGameObject.GetComponent<Animator>().Update(0.5f);
                p.snakeBodyGameObject.GetComponent<Animator>().speed = 0.0f;
            }
            if (foodMove)
            {
                foodMove = false;
            }
            else
            {
                foodMove = true;
            }

            gridMoveTimer -= gridMoveTimerMax;

            refresh = true; // zabezpieczenie ruchu

            SnakeMovePosition previousSnakeMovePosition = null;
            if(snakeMovePositionList.Count > 0)
            // spr czy obecnie mamy przynajmniej jedna pozycje
            {
                // jesli tak to bierzemy ta z indeksem 0
                previousSnakeMovePosition = snakeMovePositionList[0];
            }

            SnakeMovePosition snakeMovePosition = new SnakeMovePosition(previousSnakeMovePosition, gridPosition, gridMoveDirection);
            snakeMovePositionList.Insert(0, snakeMovePosition); // cialo weza

            Vector2Int gridMoveDirectionVector;
            switch (gridMoveDirection)
            {
                default:
                case Direction.Right:
                    gridMoveDirectionVector = new Vector2Int(+1, 0); break;
                case Direction.Left:
                    gridMoveDirectionVector = new Vector2Int(-1, 0); break;
                case Direction.Up:
                    gridMoveDirectionVector = new Vector2Int(0, +1); break;
                case Direction.Down:
                    gridMoveDirectionVector = new Vector2Int(0, -1); break;
            }
            if (levelGrid.obstacles.Contains(gridPosition + gridMoveDirectionVector))
            {
                collision = true;
                if (gridMoveDirectionVector.x != 0)
                {
                    if (levelGrid.obstacles.Contains(gridPosition + new Vector2Int(0, 1)))
                    {
                        gridMoveDirection = Direction.Down;
                        gridMoveDirectionVector = new Vector2Int(0, -1);
                    }
                    else if (levelGrid.obstacles.Contains(gridPosition + new Vector2Int(0, -1)))
                    {
                        gridMoveDirection = Direction.Up;
                        gridMoveDirectionVector = new Vector2Int(0, 1);
                    }
                    else
                    {
                        gridMoveDirectionVector = new Vector2Int(0, -1 + 2 * rng.Next(2));
                        if (gridMoveDirectionVector.y == 1)
                        {
                            gridMoveDirection = Direction.Up;
                        }
                        else
                        {
                            gridMoveDirection = Direction.Down;
                        }
                    }

                }
                else
                {
                    if (levelGrid.obstacles.Contains(gridPosition + new Vector2Int(1, 0)))
                    {
                        gridMoveDirection = Direction.Left;
                        gridMoveDirectionVector = new Vector2Int(-1,0);
                    }
                    else if (levelGrid.obstacles.Contains(gridPosition + new Vector2Int(-1, 0)))
                    {
                        gridMoveDirection = Direction.Right;
                        gridMoveDirectionVector = new Vector2Int(1, 0);
                    }
                    else
                    {
                        gridMoveDirectionVector = new Vector2Int(-1 + 2 * rng.Next(2),0);
                        if (gridMoveDirectionVector.x == 1)
                        {
                            gridMoveDirection = Direction.Right;
                        }
                        else
                        {
                            gridMoveDirection = Direction.Left;
                        }
                    }
                }
            }

            if (collision)
            {
                hp--;
                SoundManager.PlaySound(SoundManager.Sound.Barrier);
                score.GetComponent<ScoreWindow>().lowerHp(hp);
                if (hp <= 0)
                {
                    state = State.Dead;
                    SoundManager.PlaySound(SoundManager.Sound.SnakeDie);
                    GameHandler.SnakeDied();
                }

            }
            collision = false;
            gridPosition += gridMoveDirectionVector;

            gridPosition = levelGrid.ValidateGridPosition(gridPosition);
            if (levelGrid.TrySnakeEatHpApple(gridPosition))
            {
                hp++;
                SoundManager.PlaySound(SoundManager.Sound.Heart);
                score.GetComponent<ScoreWindow>().increaseHp(hp);
            }
            if (foodMove)
            {
                if (!levelGrid.updateFoodPosition(snakeBodyPartList))
                {
                    hp--;
                    score.GetComponent<ScoreWindow>().lowerHp(hp);

                }
            }

            bool snakeAteFood = false;
            snakeAteFood = levelGrid.TrySnakeEatFood(gridPosition);
            foreach (SnakeBodyPart p in snakeBodyPartList)
            {
                if (levelGrid.TrySnakeEatFood(p.GetGridPosition()))
                {
                    snakeAteFood = true;
                }
            }
             
            if (snakeAteFood)
            {
                // jesli waz zje jedzenie, wtedy cialo rosnie
                snakeBodySize++;
                CreateSnakeBody();
                SoundManager.PlaySound(SoundManager.Sound.SnakeEat); // funkcja odtwarzjaca dzwiek
            }

            if (snakeMovePositionList.Count >= snakeBodySize + 1)
            {
                // spr ile elemantow mamy na naszej liscie
                // jesli ich liczba jest taka sama lub wieksza 
                // niz dl ciala weza + 1
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
                // to usuwamy ostatni element z listy              
            }
            UpdateSnakeBodyParts();

            // zeby snake nie najezdzal na swoje cialo
            foreach (SnakeBodyPart snakeBodyPart in snakeBodyPartList) 
            {
                Vector2Int snakeBodyPartGridPosition = snakeBodyPart.GetGridPosition();
                
                if (gridPosition == snakeBodyPartGridPosition )
                {
                    // sprawdz pozycje siatki, ktora jest pozycja glowy, jesli jest
                    // taka sama jak pozycja siatki czesci ciala weza to koniec gry
                   // CMDebug.TextPopup("DEAD!", transform.position);
                    state = State.Dead;
                    GameHandler.SnakeDied();
                    SoundManager.PlaySound(SoundManager.Sound.SnakeDie); // funkcja odtwarzjaca dzwiek
                }

            }

            if (rng.Next(20) == 0 && hp<5)
            {
                levelGrid.SpawnHpApple();
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirectionVector) - 90);
            // rotation, pobieramy kat z wektora i kierunek ruchu

        }
    }


    private void CreateSnakeBody()
    {
        snakeBodyPartList.Add(new SnakeBodyPart(snakeBodyPartList.Count));
    }
    private void UpdateSnakeBodyParts()
    {
        for (int i = 0; i < snakeBodyPartList.Count; i++)
        {
            snakeBodyPartList[i].SetSnakeMovePosition(snakeMovePositionList[i]);
        }
    }


    private float GetAngleFromVector(Vector2Int dir)
    // pobiera wektor do int i zwraca liczbe, aby uzyskac kat
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }

    // Funkcja zwracjaca pełną listę pozycji zajmowaną przez weza - glowa + cialo
    public List<Vector2Int> GetFullSnakeGridPositionList()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>() { gridPosition };
        foreach (SnakeMovePosition snakeMovePosition in snakeMovePositionList)
        {
            gridPositionList.Add(snakeMovePosition.GetGridPosition());
        }

        return gridPositionList;
    }


    public class SnakeBodyPart
    {
        private SnakeMovePosition snakeMovePosition;
        private Transform transform;
        public GameObject snakeBodyGameObject;
        public SnakeBodyPart(int bodyIndex)
        {
            // tworzymy nowy obiekt gry nazywając go SnakeBody i dodajemy 
            // go z komponentem renderujacym postac i odpowiednim cialem sprite
            
            if(bodyIndex%2 == 0)
            {
                snakeBodyGameObject = Instantiate(GameAssets.i.bodyR);
            }
            else
            {
                snakeBodyGameObject = Instantiate(GameAssets.i.bodyL);
            }
            
            snakeBodyGameObject.GetComponent<SpriteRenderer>().sortingOrder = bodyIndex+1;
            snakeBodyGameObject.GetComponent<Animator>().speed = 0.0f;
            //tworzymy nowy obiekt gry i dodajemy go do naszej listy

            transform = snakeBodyGameObject.transform;
        }
        public void SetSnakeMovePosition(SnakeMovePosition snakeMovePosition)
        {
            this.snakeMovePosition = snakeMovePosition;
            transform.position = new Vector3(snakeMovePosition.GetGridPosition().x, snakeMovePosition.GetGridPosition().y);

            float angle; // kat dla ciala
            switch (snakeMovePosition.GetDirection())
            {
                // radzenie sobie z zakretami
                default:

                case Direction.Up: // obecnie idzie w gore
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default:
                            angle = 0; break;
                        case Direction.Left: // poprzednio szedl w lewo
                            angle = 0 + 45; break;
                        case Direction.Right: // poprzednio szedl w prawo
                            angle = 0 - 45; break;
                    }
                    break;



                case Direction.Down: // obecnie idzie w dol
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default:
                            angle = 180; break;
                        case Direction.Right: // poprzednio szedl w lewo
                            angle = 180 + 45; break;
                        case Direction.Left: // poprzednio szedl w prawo
                            angle = 180 - 45; break;
                    }
                    break;



                case Direction.Left: // obecnie idzie w lewo
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default:
                            angle = 90; break;
                        case Direction.Down: // poprzednio szedl w dol
                            angle = 135; break;
                        case Direction.Up: // poprzednio szedl w gore
                            angle = 45; break;
                    }
                    break;



                case Direction.Right: // obecnie idzie w prawo
                    switch (snakeMovePosition.GetPreviousDirection())
                    {
                        default:
                            angle = -90; break;
                        case Direction.Down: // poprzednio szedl w dol
                            angle = -135; break;
                        case Direction.Up: // poprzednio szedl w gore
                            angle = -45; break;
                    }
                    break;
            }

            transform.eulerAngles = new Vector3(0, 0, angle);
            // tranformujemy katy
        }


        public Vector2Int GetGridPosition()
        {
            return snakeMovePosition.GetGridPosition();
        }

    }

    // obsluga jednego ruchu pozycji od weza
    public class SnakeMovePosition
    {
        // poprzedni pozycja ruchu weza potrzeba do rotacji cialem
        private SnakeMovePosition previousSnakeMovePosition; 
        private Vector2Int gridPosition;
        private Direction direction;

        public SnakeMovePosition(SnakeMovePosition previousSnakeMovePosition, Vector2Int gridPosition, Direction direction)
        {
            this.previousSnakeMovePosition = previousSnakeMovePosition;
            this.gridPosition = gridPosition;
            this.direction = direction;
        }

        public Vector2Int GetGridPosition()
        {
            return gridPosition;
        }

        public Direction GetDirection()
        {
            return direction;
        }
        public Direction GetPreviousDirection()
        {
            if(previousSnakeMovePosition == null)
            {
                return Direction.Right;
            }
            else
            {
                return previousSnakeMovePosition.direction;
            }

        }
    }
 }

 
