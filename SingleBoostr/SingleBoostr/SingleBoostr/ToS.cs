using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleBoostr
{
    class ToS
    {
        public static string GetTermsOfService(string language)
        {
            switch (language)
            {
                case "uk":
                    /*Ukrainian*/
                    return "Будь ласка, прийміть наступні умови угоди, перш ніж продовжити:\n\n"

                        + "Використання даної програми не призведе до VAC бану вашого акаунта. У будь-якому випадку, автор не несе за "
                        + "собою відповідальності за будь-які блокування, які ви можете отримати. Ми сподіваємося, що ви достатньо "
                        + "розумні, щоб не використовувати чіт-програми на своєму акаунті після цього звинувачувати "
                        + "в причини блокування дану програму і автора.\n\n"

                        + "Чи згодні ви з даними умовами?\n"
                        + "Відмова від умов угоди призведе до скасування установки.\n\n"
                        + "Translation by: woodaphonech";

                case "no":
                    /*Norwegian*/
                    return "Vennligst godta følgende vilkår før du fortsetter:\n\n"

                        + "Dette programmet vil ikke føre til at kontoen din for å få VAC utestengt. Imidlertid vil jeg ta "
                        + "intet ansvar hvis en eller annen grunn kontoen din blir utestengt. Jeg håper du er smart "
                        + "nok til ikke å jukse på kontoen din, og deretter skylde på dette programmet eller meg.\n\n"

                        + "Forstår du og samtykker til dette?\n"
                        + "Ved å trykke 'No' vil avslutte programmet.\n\n"
                        + "Translation by: K-market";

                case "fr":
                    /*French*/
                    return "Sil vous plaît acceptez les conditions suivante avant de continuer:\n\n"

                        + "Ce programme ne causera pas de bannissement vac sur votre compte. Je ne prends aucune "
                        + "si pour n'importe quel raison vous vous faite bannir. J'espère que vous êtes assez intelligent "
                        + "pour ne pas tricher sur votre compte. Et de rejeter la faute sur le logiciel ou moi.\n\n"

                        + "Comprenez vous et accepter ceci?\n"
                        + "Appuyer sur 'No' fermera le programme.\n\n"
                        + "Translation by: Yzabri";

                case "lv":
                    /*Latvian, Lettish*/
                    return "Lūdzu piekrītiet šādiem noteikumiem pirms turpināt:\n\n"

                        + "Šī programma neizraisīs VAC banu. Tomēr es neuzņemos atbildību, ja kāda iemesla "
                        + "dēļ jūsu konts tiek nobanots. Es ceru ,ka esat pietiekami gudrs lai nekrāptos "
                        + "uz sava konta un vainot šo programmu vai mani.\n\n"

                        + "Vai jūs saprotiet un piekrītiet?\n"
                        + "Spiežot 'No' jūs iziesiet no programmas.\n\n"
                        + "Translation by: Katracy";

                case "sq":
                    /*Albanian*/
                    return "Ju lutem pranoni kushtet e mëposhtme para se te vazhdoni:\n\n"

                        + "Ky program nuk do të shkaktojë nje VAC Ban në llogarinë tuaj. Megjithatë, unë nuk marrë asnjë "
                        + "përgjegjësi në qoftë se për ndonjë arsye llogaria juaj bllokohet. Unë shpresoj se ju jeni mjaft "
                        + "i zgjuar për të mos perdorur hilera në llogarinë tuaj dhe pastaj të fajësoni këtë program ose mua.\n\n"

                        + "A e kuptoni dhe bini dakord me këtë?\n"
                        + "Shtypja 'No' do të mbyllë programin.\n\n"
                        + "Translation by: Xenomorph";

                case "da":
                    /*Danish*/
                    return "Venligst accepter de følgende regler, før du forsætter:\n\n"

                        + "Dette program vil ikke påføre din konti et VAC ban. Men, Jeg tager fratager mig "
                        + "ethvert ansvar, hvis din konti bliver VAC banned. Jeg håber du er klog nok til ikke at snyde "
                        + "på din konti, og så derefter påstå at det var programmet eller mig som forårsagede det.\n\n"

                        + "Forstår og accepter du disse forhold?\n"
                        + "Tryk på 'No' vil lukke programmet.\n\n"
                        + "Translation by: StregKoden";

                case "in":
                    /*Indonesian*/
                    return "Silakan setuju dengan persyaratan berikut sebelum Anda melanjutkan:\n\n"

                        + "Program ini tidak akan menyebabkan akun Anda untuk mendapatkan VAC ban. Namun Saya tidak "
                        + "bertanggung jawab atas alasan apapun account Anda akan terkena ban. Saya harap Anda cukup cerdas "
                        + "untuk tidak menggunakan cheat pada akun Anda dan kemudian menyalahkan program ini atau saya.\n\n"

                        + "Apakah Anda memahami dan setuju dengan hal ini?\n"
                        + "Menekan 'No' akan keluar dari program.\n\n"
                        + "Translation by: Kevin Franz";

                case "de":
                    /*German*/
                    return "Bitte akzeptieren Sie folgende Bedingungen bevor Sie fortfahren:\n\n"

                        + "Durch dieses Programm wird ihr Account nicht VAC gebannt, jedoch übernehme ich keinerlei Verantwortung "
                        + "und/oder Haftung, falls ihr Account doch gebannt werden sollte. Da es sich im Grunde genommen "
                        + "hierbei um cheating handelt und eine sperre erfolgen sollte, beschuldigen sie bitte weder mich, noch das Programm.\n\n"

                        + "Falls Sie diese Bedingungen nicht akzeptieren sollten "
                        + "drücken Sie bitte 'No' und das Programm wird sich automatisch schließen.\n\n"
                        + "Translation by: SCHUTZBUNK3R and hERO";

                case "be":
                case "ru":
                    /*Russian*/
                    return "Пожалуста, примите следующие условия соглашения прежде чем продолжить:\n\n"

                        + "Использование этой программы не приведёт к VAC бану. В любом случае, я не несу "
                        + "ответственности за любые блокировки, которые вы получите. Я надеюсь вы достаточно умны "
                        + "чтобы не использовать читы на своём аккаунте и после этого флеймить на мою программу или меня.\n\n"

                        + "Согласны ли вы с данными условиями?\n"
                        + "Нажатие кнопки 'No' приведёт к выходу из программы.\n\n"
                        + "Translation by: Esquire";

                case "fi":
                    /*Finnish*/
                    return "Jatkaaksesi, hyväksy seuraavat ehdot:\n\n"

                        + "Tämä ohjelma ei tule aiheuttamaan sinulle VAC bannia. Kuitenkaan, en ota mitään "
                        + "vastuuta jos mistään syystä käyttäjäsi saa bannit. Toivottavasti olet tarpeeksi "
                        + "viisas olemaan käyttämättä huijauskoodeja ja sitten syyttämään tätä ohjelmaa/minua.\n\n"

                        + "Ymmärrätkö ja hyväksytkö nämä ehdot?\n"
                        + "Painamalla 'No' suljet ohjelman.\n\n"
                        + "Translation by: LazyKernel";

                case "pt":
                case "br":
                    /*Portuguese*/
                    return "Por favor concorde com os seguintes termos antes de continuar:\n\n"

                        + "Este programa não vai causar banimento por VAC em sua conta. Porém, eu não vou levar a responsabilidade "
                        + "se por qualquer razão sua conta for banida. Eu espero que você seja inteligente o suficiente "
                        + "para não trapacear na sua conta e depois colocar a culpa no programa ou em mim.\n\n"

                        + "Você entende e concorda com isso?\n"
                        + "Aperte 'No' para sair do programa.\n\n"
                        + "Translation by: Vaan and Kirigaya";

                case "sv":
                    /*Swedish*/
                    return "Du måste godkänna följande användarvillkor innan du fortsätter:\n\n"

                        + "Användandet av detta program kommer inte att orsaka ett VAC-ban för ditt account. Jag kommer däremot "
                        + "inte ta ansvar för ditt konto om du av någon anledning blir VAC-Bannad. Jag hoppas att du är smart "
                        + "nog att inte fuska i spel och sedan skylla på detta program eller mig om du blir bannad.\n\n"

                        + "Godkänner du användarvillkoren?\n"
                        + "Om du trycker 'No' så kommer programmet att avslutas.\n\n"
                        + "Translation by: much woof";

                case "pirate":
                    /*Pirate*/
                    return "Please agree to th' followin' terms before ye continue:\n\n"

                        + "'tis program gunna not cause ye account to get VAC banned. However, I gunna take no responsibility "
                        + "if fer any reason ye account gets banned. I woe ye be smart that be all I can take not to cheat "
                        + "on ye account 'n then blame it on 'tis program or me.\n\n"

                        + "Do ye understand 'n agree to 'tis?\n"
                        + "Pressin' NO gunna exit th' program.\n\n"
                        + "Translation by: Blackbeard";

                default:
                    /*English*/
                    return "Please agree to the following terms before you continue:\n\n"

                        + "This program will not cause your account to get VAC banned. However, I will take "
                        + "no responsibility if for any reason your account gets banned. I hope you are smart "
                        + "enough not to cheat on your account and then blame it on this program or me.\n\n"

                        + "Do you understand and agree to this?\n"
                        + "Pressing 'No' will exit the program.";
            }
        }
    }
}
