using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAntony.CrudTests
{
    public class SeasonCrud : GenericDatabaseCrud<Season>
    {



        public SeasonComponent Options { get; protected set; }

        public SeasonCrud(dboEntities1 database, GenericFormCore core, SeasonComponent options) : base(database, database.Seasons, core)
        {
         
            Options = (SeasonComponent)options;
        }

        protected override ListboxEntry<Season> NameEntry(Season season)
        {
            return new StandardListboxEntry<Season>(season, season.name);
        }

        public override void BindOptionComponent()
        {
            Options.SeasonLabel.Click += seasonLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = true;
            Options.NameText.Visible = true;
            Options.SeasonLabel.Enabled = true;
            Options.SeasonLabel.Visible = true;
        }

        public override void UnbindOptionComponent()
        {
            Options.SeasonLabel.Click -= seasonLabel_Click;
            Options.NameText.Text = "";
            Options.NameText.Enabled = false;
            Options.NameText.Visible = false;
            Options.SeasonLabel.Enabled = false;
            Options.SeasonLabel.Visible = false;
        }

        public override void SelectItem(ListboxEntry<Season> item)
        {
            Season season = item.Entry;
            TextBox txt = Options.NameText;
            txt.Text = season.name == null ? "" : season.name;

        }

        public override void SubmitAdd()
        {
            String name = Options.NameText.Text;
            Options.NameText.Text = "";
            Season season = new Season() { name = name };
            DataSet.Add(season);
            SaveChanges();
        }

        public override void SubmitDelete()
        {

            Season season = (Season)SelectedEntry.Entry;
            Options.NameText.Text = "";
            DataSet.Remove(season);
            SaveChanges();
        }

        public override void SubmitUpdate()
        {
            Season season = (Season)SelectedEntry.Entry;
            String name = Options.NameText.Text;

            if (season == null)
                return;
            season.name = name;
            SaveChanges();
        }


        public interface SeasonComponent : GenericFormOptions
        {
            TextBox NameText { get; }
            Label SeasonLabel { get; }
        }

        private void seasonLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editing Seasons Boi!!");
        }
    }

}
