
using BaseBall;
using System.Reflection;

namespace BaseBall
{
    public struct Stats
    {
        private byte strength;
        private byte speed;
        private byte stamina;
        private byte accuracy;

        public Stats(byte strength, byte speed, byte stamina, byte accuracy)
        {
            this.strength = strength;
            this.speed = speed;
            this.stamina = stamina;
            this.accuracy = accuracy;
        }

        public byte Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public byte Stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }

        public byte Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public byte Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public override string ToString()
        {
            return $"STR:{strength} SPD:{speed} STA:{stamina} ACC:{accuracy}";
        }
    }
    //----------------------------------------------
    public abstract class CharacterBase
    {
        private string username;
        protected Stats stats;
        private bool isAthletic;
        private bool isAgile;
        private bool isTenacious;
        private bool isSharp;

        protected CharacterBase(string username, Stats stats)
        {
            this.username = username;
            this.stats = stats;
        }

        public Stats Stats
        {
            get
            {
                return stats;
            }
            set
            {
                stats = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public bool IsAthletic
        {
            get
            {
                return isAthletic;
            }
            set
            {
                isAthletic = value;
            }
        }

        public bool IsAgile
        {
            get
            {
                return isAgile;
            }
            set
            {
                isAgile = value;
            }
        }

        public bool IsTenacious
        {
            get
            {
                return isTenacious;
            }
            set
            {
                isTenacious = value;
            }
        }

        public bool IsSharp
        {
            get
            {
                return isSharp;
            }
            set
            {
                isSharp = value;
            }
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Stats: {stats}");
            Console.WriteLine($"Traits: Athletic:{isAthletic} Agile:{isAgile} Tenacious:{isTenacious} Sharp:{isSharp}");
        }
    }

    public class CustomizeableCharacter : CharacterBase
    {
        private string gender;
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        private string bodyType;
        public string BodyType
        {
            get
            {
                return bodyType;
            }
            set
            {
                bodyType = value;
            }
        }
        private string skinColor;
        public string SkinColor
        {
            get
            {
                return skinColor;
            }
            set
            {
                skinColor = value;
            }
        }
        private string hairColor;
        public string HairColor
        {
            get
            {
                return hairColor;
            }
            set
            {
                hairColor = value;
            }
        }
        private string eyeColor;
        public string EyeColor
        {
            get
            {
                return eyeColor;
            }
            set
            {
                eyeColor = value;
            }
        }
        private string eyebrowThickness;
        public string EyebrowThickness
        {
            get
            {
                return eyebrowThickness;
            }
            set
            {
                eyebrowThickness = value;
            }
        }
        private string baseballBatTexture;
        public string BaseballBatTexture
        {
            get
            {
                return baseballBatTexture;
            }
            set
            {
                baseballBatTexture = value;
            }
        }
        private string baseballBatDesign;
        public string BaseballBatDesign
        {
            get
            {
                return baseballBatDesign;
            }
            set
            {
                baseballBatDesign = value;
            }
        }
        private string socks;
        public string Socks
        {
            get
            {
                return socks;
            }
            set
            {
                socks = value;
            }
        }
        private string shoes;
        public string Shoes
        {
            get
            {
                return shoes;
            }
            set
            {
                shoes = value;
            }
        }
        private string cap;
        public string Cap
        {
            get
            {
                return cap;
            }
            set
            {
                cap = value;
            }
        }
        private string shirtDesign;
        public string ShirtDesign
        {
            get
            {
                return shirtDesign;
            }
            set
            {
                shirtDesign = value;
            }
        }
        private string pantsDesign;
        public string PantsDesign
        {
            get
            {
                return pantsDesign;
            }
            set
            {
                pantsDesign = value;
            }
        }
        private string accessories;
        public string Accessories
        {
            get
            {
                return accessories;
            }
            set
            {
                accessories = value;
            }
        }
        private string preferredPosition;
        public string PreferredPosition
        {
            get
            {
                return preferredPosition;
            }
            set
            {
                preferredPosition = value;
            }
        }
        private string teamMascot;
        public string TeamMascot
        {
            get
            {
                return teamMascot;
            }
            set
            {
                teamMascot = value;
            }
        }
        private string perks;
        public string Perks
        {
            get
            {
                return perks;
            }
            set
            {
                perks = value;
            }
        }

        public CustomizeableCharacter(string username, Stats stats) : base(username, stats)
        {
            gender = "None";
            bodyType = "None";
            skinColor = "None";
            hairColor = "None";
            eyeColor = "None";
            eyebrowThickness = "None";
            baseballBatTexture = "None";
            baseballBatDesign = "None";
            socks = "None";
            shoes = "None";
            cap = "None";
            shirtDesign = "None";
            pantsDesign = "None";
            accessories = "None";
            preferredPosition = "None";
            teamMascot = "None";
            perks = "None";
        }

        public override void ShowInfo()
        {
            Console.WriteLine("=== Character Information ===\n");
            base.ShowInfo();
            Console.WriteLine($"GENDER: {gender}");
            Console.WriteLine($"BODY TYPE: {bodyType}");
            Console.WriteLine($"SKIN COLOR: {skinColor}");
            Console.WriteLine($"HAIR COLOR: {hairColor}");
            Console.WriteLine($"EYE COLOR: {eyeColor}");
            Console.WriteLine($"EYEBROW THICKNESS: {eyebrowThickness}");
            Console.WriteLine($"BAT TEXTURE: {baseballBatTexture}");
            Console.WriteLine($"BAT DESIGN: {baseballBatDesign}");
            Console.WriteLine($"SHOES: {shoes}");
            Console.WriteLine($"SHIRT DESIGN: {shirtDesign}");
            Console.WriteLine($"PANTS DESIGN: {pantsDesign}");
            Console.WriteLine($"ACCESSORIES: {accessories}");
            Console.WriteLine($"CAP (HEADWEAR): {cap}");
            Console.WriteLine($"SOCKS: {socks}");
            Console.WriteLine($"PREFERRED POSITION: {preferredPosition}");
            Console.WriteLine($"TEAM MASCOT: {teamMascot}");
            Console.WriteLine($"PERKS: {perks}");
        }
    }
}