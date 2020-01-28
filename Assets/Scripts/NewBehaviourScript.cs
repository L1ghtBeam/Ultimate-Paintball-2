var playerTeam1 : Transform;
var playerTeam2 : Transform;
var spawnpoint1 : GameObject;
var spawnpoint2 : GameObject;

 
 function OnGUI () {
 if (GUI.Button (new Rect(10, 10, 100, 30), "Team Name1")) {
    Network.Instantiate(playerTeam1, spawnpoint1.transform, spawnpoint1.rotation);
 }
 if (GUI.Button (new Rect(10, 50, 100, 30), "Team Name2")) {
    Network.Instantiate(playerTeam2, spawnpoint2.transform, spawnpoint2.rotation);
 }
}
