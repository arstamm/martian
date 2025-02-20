using System;
using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;


namespace Unit06.Game.Scripting
{
    public class CollideItemsAction : Action
    {
        private PhysicsService physicsService;
        
        public CollideItemsAction(PhysicsService physicsService)
        {
            this.physicsService = physicsService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player) cast.GetFirstActor(Constants.PLAYER_GROUP);
            Body playerBody = player.GetBody();
            Stats stats = (Stats) cast.GetFirstActor(Constants.STATS_GROUP);

            CollideScrap(cast, stats, playerBody, Constants.SCRAP_GROUP);
            CollideHealth(cast, stats, playerBody, Constants.DEBREE_GROUP);
            CollideHealth(cast, stats, playerBody, Constants.FOOD_GROUP);
            CollideHealth(cast, stats, playerBody, Constants.WATER_GROUP);
        }

        private void CollideScrap(Cast cast, Stats stats, Body body, string itemGroup)
        {
            foreach (Item item in cast.GetActors(itemGroup))
            {
                if (physicsService.HasCollided(item.GetBody(), body))
                {
                    stats.AddScrap();
                    cast.RemoveActor(itemGroup, item);
                }
            }

        }

        private void CollideHealth(Cast cast, Stats stats, Body body, string itemGroup)
        {
            foreach (Item item in cast.GetActors(itemGroup))
            {
                if (physicsService.HasCollided(item.GetBody(), body))
                {
                    stats.AddLives(item.GetValue());
                    cast.RemoveActor(itemGroup, item);
                }
            }
        }
    }
}