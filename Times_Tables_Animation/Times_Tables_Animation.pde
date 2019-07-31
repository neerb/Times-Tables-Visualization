int points = 200; //Amount of points around the circle's perimeter : increase for a finer, more detailed image, lower for the opposite
int angleInc;
float angle = 0;
float radius;
float times = 1;

void setup()
{
  size(800, 800);
  angleInc = floor(360 / points);
  radius = width / 2.5;
  times = 0;//7919;///sqrt(2);
  frameRate(24);
}

void draw()
{
  background(51);
  text(times, 30, 30);
  translate(width / 2, height / 2); //Translate to center times table
  noFill();
  ellipse(0, 0, radius * 2, radius * 2); //Draws circle around times table
  
  int index = 0;

  //Continues to loop until we have completely drawn a times table
  while(angle <= 360)
  {
    stroke(255);
    strokeWeight(0.5);
    
    //Conversion from polar to cartesian coordinates
    float x = cos(angle * (PI / 180)) * radius;
    float y = sin(angle * (PI / 180)) * radius;
    
    point(x, y);
    
    float num = floor(index * times);
    
    //Conversion from polar to cartesian coordinates
    float nextX = cos(angleInc * num * (PI / 180)) * radius;
    float nextY = sin(angleInc * num * (PI / 180)) * radius;
    
    //Draws line from current coordinate to new calulated coordinate (polar)
    line(x, y, nextX, nextY);    
    
    angle += floor(angleInc);
    index++;
  }
  
  angle = 0;
  
  times += 0.0125;
}
