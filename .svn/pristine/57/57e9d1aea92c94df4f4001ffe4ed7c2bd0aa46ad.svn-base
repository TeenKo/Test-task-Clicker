using System.Collections.Generic;

namespace Adapters
{
    public class AnalyticsConfig : Core.Configs.Config
    {
        public Dictionary<string, object> GetDummyParameters()
        {
           return new EventGameLevelParameters().Dummy();
        }

        public struct EventGameLevelParameters
        {
            public Dictionary<string, object> Parameters;

            /// <summary>
            /// Событие завершения уровня
            /// </summary>
            /// <param name="gameLevelNumber">Порядковый номер уровня. При прохожденни всех уровней, если они начинаются сначала - параметр не должен продолжать расти, он показывает номер конкретного уровня который был запущен</param>
            /// <param name="gameLevelName">Название уровня</param>
            /// <param name="gameLevelCount">Порядковый номер игры для пользователя (параметр, который обновляется каждый старт уровня, то есть показывает какое количество игр пользователь сыграл за все время жизни) - Начинается с 1</param>
            /// <param name="gameLevelDiff">Сложность уровня</param>
            /// <param name="gameLevelLoop">Номер прохождения всех уровней, если они зациклены</param>
            /// <param name="gameLevelRandom">Был ли уровень выдан рандомно, 0 - нет, 1 - да</param>
            /// <param name="gameLevelType">Тип уровня (для разделения типов уровней внутри одного game_mode. Например для бонусных уровней)</param>
            /// <param name="gameLevelMode">Режим игры, если в приложении их больше одного</param>
            /// <param name="gameLevelResult">Тип завершения уровня</param>
            /// <param name="gameLevelTime">Время прохождения уровня в секундах</param>
            /// <param name="gameLevelProgress">Прогресс прохождения уровня, числом от 0 до 100 (процент)</param>
            /// <param name="gameLevelContinueForAd">Количество продолжений уровня за просмотр рекламы</param>
            public EventGameLevelParameters(int gameLevelNumber, string gameLevelName, int gameLevelCount, string gameLevelDiff,
                int gameLevelLoop, bool gameLevelRandom, string gameLevelType, string gameLevelMode, string gameLevelResult, int gameLevelTime,
                int gameLevelProgress, int gameLevelContinueForAd)
            {
                Parameters = new Dictionary<string, object>()
                {
                    {"level_number", gameLevelNumber}, // int 	1, 2, 3...
                    {"level_name", gameLevelName}, // str  01_name, 02_name
                    {"level_count", gameLevelCount}, // int	1, 2, 3...
                    {"level_diff", gameLevelDiff}, // str	normal
                    {"level_loop", gameLevelLoop}, // int 	1, 2, 3...
                    {"level_random", gameLevelRandom}, // bool	false - no, true - yes
                    {"level_type", gameLevelType}, // str  normal
                    {"game_mode", gameLevelMode}, // str  classic
                    {"result", gameLevelResult}, // str	win, lose, leave etc.
                    {"time", gameLevelTime}, // int	1, 2, 3...	
                    {"progress", gameLevelProgress}, // int	0 - 100	
                    {"continue", gameLevelContinueForAd} // int	1, 2, 3...	
                };
            }
            
            /// <summary>
            /// Событие старта уровня
            /// </summary>
            /// <param name="gameLevelNumber">Порядковый номер уровня. При прохожденни всех уровней, если они начинаются сначала - параметр не должен продолжать расти, он показывает номер конкретного уровня который был запущен</param>
            /// <param name="gameLevelName">Название уровня</param>
            /// <param name="gameLevelCount">Порядковый номер игры для пользователя (параметр, который обновляется каждый старт уровня, то есть показывает какое количество игр пользователь сыграл за все время жизни) - Начинается с 1</param>
            /// <param name="gameLevelDiff">Сложность уровня</param>
            /// <param name="gameLevelLoop">Номер прохождения всех уровней, если они зациклены</param>
            /// <param name="gameLevelRandom">Был ли уровень выдан рандомно, 0 - нет, 1 - да</param>
            /// <param name="gameLevelType">Тип уровня (для разделения типов уровней внутри одного game_mode. Например для бонусных уровней)</param>
            /// <param name="gameLevelMode">Режим игры, если в приложении их больше одного</param>
            public EventGameLevelParameters(int gameLevelNumber, string gameLevelName, int gameLevelCount, string gameLevelDiff,
                int gameLevelLoop, bool gameLevelRandom, string gameLevelType, string gameLevelMode)
            {
                Parameters = new Dictionary<string, object>()
                {
                    {"level_number", gameLevelNumber}, // int 	1, 2, 3...
                    {"level_name", gameLevelName}, // str  01_name, 02_name
                    {"level_count", gameLevelCount}, // int	1, 2, 3...
                    {"level_diff", gameLevelDiff}, // str	normal
                    {"level_loop", gameLevelLoop}, // int 	1, 2, 3...
                    {"level_random", gameLevelRandom}, // bool	false - no, true - yes
                    {"level_type", gameLevelType}, // str  normal
                    {"game_mode", gameLevelMode}, // str  classic
                };
            }

            public Dictionary<string, object> Dummy()
            {
                Parameters = new Dictionary<string, object>()
                {
                    {"level_number", 1},
                    {"level_name", "regular"},
                    {"level_count", 0},
                    {"level_diff", "normal"},
                    {"level_loop", 1},
                    {"level_random", false},
                    {"level_type", "normal"},
                    {"game_mode", "classic"},
                    {"result", "win"},
                    {"time", 0f},
                    {"progress", 100f},
                    {"continue", 0}
                };

                return Parameters;
            }
        }
    }
}