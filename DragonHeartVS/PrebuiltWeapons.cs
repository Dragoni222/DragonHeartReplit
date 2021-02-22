using System;
using System.Collections.Generic;
using static Items;

/*
Weapon fists = new Weapon(10000, "bludge", "Fists",
                                "1d2",new List<List<int>>() { new List<int>(){0,1,0 },
                                    new List<int>() { 0,-1,0 }, new List<int>() { 0,0,0} }, true);


Weapon woodenShortsword = new Weapon(100, "slash", "wooden shortsword",
            "1d6", new List<List<int>>{ new List<int>(){2, 2,2,2, 2},
                new List<int>() {2, 1, 1, 1, 2}, new List<int>() {1, 1, -1, 1, 1},
            new List<int>() {1, 0, 0, 0,1 }, new List<int>() { 0, 0, 0, 0, 0 } }, true );

Weapon woodenClub = new Weapon(100, "bludge", "wooden club",
            "1d5", new List<List<int>>{ new List<int>(){1,2,1},
                new List<int>() { 0, -1, 0 }, new List<int>() { 0, 0, 0 } }, true );
 */

class PremadeWeapons
{
    Weapon fists = new Weapon(10000, "bludge", "Fists",
                                "1d2", new List<List<int>>() { new List<int>(){0,1,0 },
                                    new List<int>() { 0,-1,0 }, new List<int>() { 0,0,0} }, true);


    Weapon woodenShortsword = new Weapon(100, "slash", "wooden shortsword",
                "1d6", new List<List<int>>{ new List<int>(){2, 2,2,2, 2},
                new List<int>() {2, 1, 1, 1, 2}, new List<int>() {1, 1, -1, 1, 1},
            new List<int>() {1, 0, 0, 0,1 }, new List<int>() { 0, 0, 0, 0, 0 } }, true);

    Weapon woodenClub = new Weapon(100, "bludge", "wooden club",
                "1d5", new List<List<int>>{ new List<int>(){1,2,1},
                new List<int>() { 0, -1, 0 }, new List<int>() { 0, 0, 0 } }, true);
}

