using Nickel;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using System;
using System.Collections.Generic;
using System.Linq;
namespace NoOne.NothingNobody;
public sealed class ModEntry : SimpleMod
{
    internal static ModEntry Instance { get; private set; } = null!;
    internal ILocalizationProvider<IReadOnlyList<string>> AnyLocalizations { get; }
    internal ILocaleBoundNonNullLocalizationProvider<IReadOnlyList<string>> Localizations { get; }
    internal ISpriteEntry Nothing_Character_CardBackground { get; }
    internal ISpriteEntry Nothing_Character_CardFrame { get; }
    internal ISpriteEntry Nothing_Character_Panel { get; }
    internal ISpriteEntry Nothing_Character_Neutral_0 { get; }
    internal ISpriteEntry Nothing_Character_Mini_0 { get; }
    internal IDeckEntry Nothing_Deck { get; }
    internal ISpriteEntry Nobody_Character_CardBackground { get; }
    internal ISpriteEntry Nobody_Character_CardFrame { get; }
    internal ISpriteEntry Nobody_Character_Panel { get; }
    internal ISpriteEntry Nobody_Character_Neutral_0 { get; }
    internal ISpriteEntry Nobody_Character_Mini_0 { get; }
    internal IDeckEntry Nobody_Deck { get; }

    public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
    {
        Instance = this;
        AnyLocalizations = new JsonLocalizationProvider(
            tokenExtractor: new SimpleLocalizationTokenExtractor(),
            localeStreamFunction: locale => package.PackageRoot.GetRelativeFile($"i18n/{locale}.json").OpenRead()
        );
        Localizations = new MissingPlaceholderLocalizationProvider<IReadOnlyList<string>>(
            new CurrentLocaleOrEnglishLocalizationProvider<IReadOnlyList<string>>(AnyLocalizations)
        );
        Nothing_Character_CardBackground = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nothing_character_cardbackground.png"));
        Nothing_Character_CardFrame = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nothing_character_cardframe.png"));
        Nothing_Character_Panel = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nothing_character_panel.png"));
        Nothing_Character_Neutral_0 = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nothing_character_neutral_0.png"));
        Nothing_Character_Mini_0 = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nothing_character_mini_0.png"));
        Nothing_Deck = helper.Content.Decks.RegisterDeck("NothingDeck", new DeckConfiguration()

        {
            Definition = new DeckDef()
            {
                color = new Color("202020"),
                titleColor = new Color("000000")
            },
            DefaultCardArt = Nothing_Character_CardBackground.Sprite,
            BorderSprite = Nothing_Character_CardFrame.Sprite,
            Name = AnyLocalizations.Bind(["character", "Nothing", "name"]).Localize,
        }); 
        Nobody_Character_CardBackground = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nobody_character_cardbackground.png"));
        Nobody_Character_CardFrame = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nobody_character_cardframe.png"));
        Nobody_Character_Panel = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nobody_character_panel.png"));
        Nobody_Character_Neutral_0 = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nobody_character_neutral_0.png"));
        Nobody_Character_Mini_0 = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/characters/Nobody_character_mini_0.png"));
        Nobody_Deck = helper.Content.Decks.RegisterDeck("NobodyDeck", new DeckConfiguration()

        {
            Definition = new DeckDef()
            {
                color = new Color("202020"),
                titleColor = new Color("000000")
            },
            DefaultCardArt = Nobody_Character_CardBackground.Sprite,
            BorderSprite = Nobody_Character_CardFrame.Sprite,
            Name = AnyLocalizations.Bind(["character", "Nobody", "name"]).Localize,
        });

        helper.Content.Characters.RegisterCharacterAnimation(new CharacterAnimationConfiguration()
        {
            Deck = Nothing_Deck.Deck,

            LoopTag = "neutral",
            Frames = new[]
    {
                Nothing_Character_Neutral_0.Sprite,
            }
        });
        helper.Content.Characters.RegisterCharacterAnimation(new CharacterAnimationConfiguration()
        {
            Deck = Nothing_Deck.Deck,
            LoopTag = "mini",
            Frames = new[]
            {
                Nothing_Character_Mini_0.Sprite
            }
        });
        helper.Content.Characters.RegisterCharacter("Nothing", new CharacterConfiguration()
        {

            Deck = Nothing_Deck.Deck,

            Description = AnyLocalizations.Bind(["character", "Nothing", "description"]).Localize,

            BorderSprite = Nothing_Character_Panel.Sprite
        });

        helper.Content.Characters.RegisterCharacterAnimation(new CharacterAnimationConfiguration()
        {
            Deck = Nobody_Deck.Deck,

            LoopTag = "neutral",
            Frames = new[]
           {
                Nobody_Character_Neutral_0.Sprite,
            }
        });
        helper.Content.Characters.RegisterCharacterAnimation(new CharacterAnimationConfiguration()
        {
            Deck = Nobody_Deck.Deck,
            LoopTag = "mini",
            Frames = new[]
            {
                Nobody_Character_Mini_0.Sprite
            }
        });
        helper.Content.Characters.RegisterCharacter("Nobody", new CharacterConfiguration()
        {

            Deck = Nobody_Deck.Deck,

            Description = AnyLocalizations.Bind(["character", "Nobody", "description"]).Localize,

            BorderSprite = Nobody_Character_Panel.Sprite
        });


    }
}

