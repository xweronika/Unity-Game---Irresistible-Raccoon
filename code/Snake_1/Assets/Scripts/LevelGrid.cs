using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class LevelGrid
{
    // JEDZENIE
    // pozycja dla miejsca, w ktorym zywnosc jest sparowana
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    private Vector2Int foodDir;
    private int foodPresenceTimer;
    private int width; // szerokosc
    private int height; // wysokosc
    private Snake snake;
    public List<Vector2Int> obstacles;
    bool hpAppleExists = false;
    private Vector2Int hpApplePosition;
    private GameObject hpAppleObject;
    private System.Random rng;
    private int hpApleCounter = 0;

    public LevelGrid(int width, int height) // konstruktor siatki poziomow
    {
        this.width = width;
        this.height = height;

        // FunctionPeriodic.Create(SpawnFood, 1f);
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        rng = new System.Random();
        SpawnFood();
        obstacles = new List<Vector2Int>();
    }

    private void SpawnFood()
    {
        do {
            // generujemy losowa pozycje siatki
            foodGridPosition = new Vector2Int(Random.Range(1, width), Random.Range(1, height));
            // w nawiasie otrzymujemy losowy zakres
            // od 0 szerokosci i od 0 wysokosci
        } while (snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition) != -1 || (obstacles!=null && obstacles.Contains(foodGridPosition)));
        // dopoki pozycja weza jest taka sama jak pozycja jedzenia
        // wtedy wygeneruj nowy
        // dzieki temu jedzenie nigdy sie nie odrodzi na pozycji weza


        // tworzymy nowy obiekt gry
        foodGameObject = Object.Instantiate(GameAssets.i.target);
        // ustawienie pozycji 
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
        foodDir = new Vector2Int(0, 1);
        foodPresenceTimer = 70;
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        // gdy waz sie poruszy chcemy spr czy zrobil to w tym miejscu gdzie jest jedzenie
        if(snakeGridPosition == foodGridPosition)
        {
            // jesli tak sie stanie chcemy zniszczyc obiek gry
            Object.Destroy(foodGameObject);
            SpawnFood(); // i z powrotem wracamy do funkcji tworzacej jedzenie
                         // CMDebug.TextPopupMouse("Snake ate food");
            Score.AddScore(); // dodaje punkty
            return true;
        } else
        {
            return false;
        }
    }

    // Zawijanie krawedzi

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if (gridPosition.x < 0) // lewa
        {
            gridPosition.x = width;
        }
        if (gridPosition.x > width) // prawa
        {
            gridPosition.x = 0;
        }
        if (gridPosition.y < 0) // dol
        {
            gridPosition.y = height;
        }
        if (gridPosition.y > height) // gora
        {
            gridPosition.y = 0;
        }
        return gridPosition;
    }

    public void AddObstacle(Vector3Int position)
    {
        obstacles.Add(new Vector2Int(position.x, position.y));
        // tworzymy nowy obiekt gry
        GameObject obstacle = new GameObject("Obstacle", typeof(SpriteRenderer));
        if (position.z == 1)
        {
            obstacle.GetComponent<SpriteRenderer>().sprite = GameAssets.i.obstacleTree;
            obstacle.GetComponent<SpriteRenderer>().sortingLayerName = "Trees";
        }
        else
        {
            obstacle.GetComponent<SpriteRenderer>().sprite = GameAssets.i.obstacleBush;
            obstacle.GetComponent<SpriteRenderer>().sortingLayerName = "Bushes";
            obstacle.GetComponent<SpriteRenderer>().sortingOrder = rng.Next(5);
        }
        // ustawienie pozycji 
        obstacle.transform.position = new Vector3(position.x, position.y);

    }

    public void SpawnHpApple()
    {
        if (!hpAppleExists)
        {
            hpAppleExists = true;
            hpApleCounter = 50;
            do
            {
                // generujemy losowa pozycje siatki
                hpApplePosition = new Vector2Int(Random.Range(1, width), Random.Range(1, height));
                // w nawiasie otrzymujemy losowy zakres
                // od 0 szerokosci i od 0 wysokosci
            } while (snake.GetFullSnakeGridPositionList().IndexOf(hpApplePosition) != -1 || (obstacles != null && obstacles.Contains(hpApplePosition)) || hpApplePosition == foodGridPosition);
            // dopoki pozycja weza jest taka sama jak pozycja jedzenia
            // wtedy wygeneruj nowy
            // dzieki temu jedzenie nigdy sie nie odrodzi na pozycji weza


            // tworzymy nowy obiekt gry
            hpAppleObject = new GameObject("Food", typeof(SpriteRenderer));
            hpAppleObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.hpApple;
            // ustawienie pozycji 
            hpAppleObject.transform.position = new Vector3(hpApplePosition.x, hpApplePosition.y);
        }
    }
    public bool TrySnakeEatHpApple(Vector2Int snakeGridPosition)
    {

        if (hpAppleExists)
        {
            hpApleCounter--;
            // gdy waz sie poruszy chcemy spr czy zrobil to w tym miejscu gdzie jest jedzenie
            if (snakeGridPosition == hpApplePosition)
            {
                // jesli tak sie stanie chcemy zniszczyc obiek gry
                Object.Destroy(hpAppleObject);
                hpAppleExists = false;
                return true;
            }
            else
            {
                if (hpApleCounter < 0 && rng.Next(10) == 0)
                {
                    Object.Destroy(hpAppleObject);
                    hpAppleExists = false;
                }
                return false;
            }
        }
        else return false;

    }

    public bool updateFoodPosition(List<Snake.SnakeBodyPart> snakeBodyParts)
    {
        foodPresenceTimer--;

        foodGameObject.GetComponent<Animator>().speed = 1.0f;
        foodGameObject.GetComponent<Animator>().Update(0.0f);
        foodGameObject.GetComponent<Animator>().Update(0.5f);
        foodGameObject.GetComponent<Animator>().speed = 0.0f;
        bool leftCollision = false;
        bool rightCollision = false;
        bool upCollision = false;
        bool downCollision = false;
        bool currentCollision = false;
        Vector2Int positionTemp = foodGridPosition;
        leftCollision = checkCollisions(positionTemp + new Vector2Int(-1, 0), snakeBodyParts);
        positionTemp = foodGridPosition;
        rightCollision = checkCollisions(positionTemp + new Vector2Int(1, 0), snakeBodyParts);
        positionTemp = foodGridPosition;
        upCollision = checkCollisions(positionTemp + new Vector2Int(0, 1), snakeBodyParts);
        positionTemp = foodGridPosition;
        downCollision = checkCollisions(positionTemp + new Vector2Int(0, -1), snakeBodyParts);
        positionTemp = foodGridPosition;
        currentCollision = checkCollisions(positionTemp + foodDir, snakeBodyParts);

        if (rng.Next(4) == 0 || currentCollision)
        {
            if(foodDir.x != 0)
            {
                if(rng.Next(2) == 0 && !upCollision)
                {
                    foodDir.x = 0;
                    foodDir.y = 1;
                    foodGameObject.transform.rotation = new Quaternion();
                    foodGameObject.transform.Rotate(new Vector3(0, 0, 0), Space.Self);
                }
                else if(!downCollision)
                {
                    foodDir.x = 0;
                    foodDir.y = -1;
                    foodGameObject.transform.rotation = new Quaternion();
                    foodGameObject.transform.Rotate(new Vector3(0, 0, 180), Space.Self);
                }
                else if(currentCollision)
                {
                    foodDir.x = -foodDir.x;
                    foodGameObject.transform.Rotate(new Vector3(0, 0, 180), Space.Self);
                }
            }
            else
            {
                
                if (rng.Next(2) == 0 && !rightCollision)
                {
                    foodDir.y = 0;
                    foodDir.x = 1;
                    foodGameObject.transform.rotation = new Quaternion();
                    foodGameObject.transform.Rotate(new Vector3(0, 0, 270),Space.Self);
                }
                else if(!leftCollision)
                {
                    foodDir.y = 0;
                    foodDir.x = -1;
                    foodGameObject.transform.rotation = new Quaternion();
                    foodGameObject.transform.Rotate(new Vector3(0, 0, 90), Space.Self);
                }
                else if(currentCollision)
                {
                    foodDir.y = -foodDir.y;
                    foodGameObject.transform.Rotate(new Vector3(0, 0, 180), Space.Self);
                }
            }
        }
        foodGridPosition += foodDir;
        if (foodGridPosition.x > width || foodGridPosition.x < 0 || foodGridPosition.y > height || foodGridPosition.y < 0)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            return false;
        }
        else
        {
            foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
            return true;
        }
        
    }

    private bool checkCollisions(Vector2Int position, List<Snake.SnakeBodyPart> snakeBodyParts)
    {
        bool collisionSnake = false;
        foreach (Snake.SnakeBodyPart p in snakeBodyParts)
        {
            if (p.GetGridPosition() == position)
            {
                collisionSnake = true;
            }
        }
        bool collisionObstacle = obstacles.Contains(position);
        bool collisionWall = (foodPresenceTimer > 0 && (position.x > width || position.x < 0 || position.y > height || position.y < 0));
        return collisionSnake || collisionWall || collisionObstacle;
    }
}
