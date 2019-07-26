// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
namespace Rock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    ///
    /// </summary>
    public partial class SequencesToStreaks : Rock.Migrations.RockMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            TableChangesUp();
            PagesAndBlocksUp();
            JobUp();
        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            JobDown();
            PagesAndBlocksDown();
            TableChangesDown();            
        }

        private void TableChangesUp()
        {
            RenameTable( name: "dbo.SequenceOccurrenceExclusion", newName: "StreakTypeExclusion" );
            RenameTable( name: "dbo.Sequence", newName: "StreakType" );
            RenameTable( name: "dbo.SequenceEnrollment", newName: "Streak" );
            RenameColumn( table: "dbo.Streak", name: "SequenceId", newName: "StreakTypeId" );
            RenameColumn( table: "dbo.StreakTypeExclusion", name: "SequenceId", newName: "StreakTypeId" );
            RenameIndex( table: "dbo.Streak", name: "IX_SequenceId", newName: "IX_StreakTypeId" );
            RenameIndex( table: "dbo.Streak", name: "IX_SequenceId_PersonAliasId", newName: "IX_StreakTypeId_PersonAliasId" );
            RenameIndex( table: "dbo.StreakTypeExclusion", name: "IX_SequenceId", newName: "IX_StreakTypeId" );
            AddColumn( "dbo.Streak", "InactiveDateTime", c => c.DateTime() );
            AddColumn( "dbo.Streak", "ExclusionMap", c => c.Binary() );
        }

        private void TableChangesDown()
        {
            DropColumn( "dbo.Streak", "ExclusionMap" );
            DropColumn( "dbo.Streak", "InactiveDateTime" );
            RenameIndex( table: "dbo.StreakTypeExclusion", name: "IX_StreakTypeId", newName: "IX_SequenceId" );
            RenameIndex( table: "dbo.Streak", name: "IX_StreakTypeId_PersonAliasId", newName: "IX_SequenceId_PersonAliasId" );
            RenameIndex( table: "dbo.Streak", name: "IX_StreakTypeId", newName: "IX_SequenceId" );
            RenameColumn( table: "dbo.StreakTypeExclusion", name: "StreakTypeId", newName: "SequenceId" );
            RenameColumn( table: "dbo.Streak", name: "StreakTypeId", newName: "SequenceId" );
            RenameTable( name: "dbo.Streak", newName: "SequenceEnrollment" );
            RenameTable( name: "dbo.StreakType", newName: "Sequence" );
            RenameTable( name: "dbo.StreakTypeExclusion", newName: "SequenceOccurrenceExclusion" );
        }

        private void PagesAndBlocksUp()
        {
            RockMigrationHelper.AddPage( true, "B0F4B33D-DD11-4CCC-B79D-9342831B8701", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Engagement", "", SystemGuid.Page.ENGAGEMENT, "" ); // Site:Rock RMS
            RockMigrationHelper.AddBlock( true, SystemGuid.Page.ENGAGEMENT.AsGuid(), null, "C2D29296-6A87-47A9-A753-EE4E9159C4C4".AsGuid(), "CACB9D1A-A820-4587-986A-D66A69EE9948".AsGuid(), "Page Menu", "Main", @"", @"", 1, "7EF5C2D7-E20B-4955-B09B-E31F3CC20B42" );
            RockMigrationHelper.AddBlockAttributeValue( "7EF5C2D7-E20B-4955-B09B-E31F3CC20B42", "1322186A-862A-4CF1-B349-28ECB67229BA", @"{% include '~~/Assets/Lava/PageListAsBlocks.lava' %}" );

            RockMigrationHelper.UpdatePageParent( SystemGuid.Page.STEP_PROGRAMS, SystemGuid.Page.ENGAGEMENT );
            RockMigrationHelper.UpdatePageParent( SystemGuid.Page.STREAK_TYPES, SystemGuid.Page.ENGAGEMENT );
        }

        private void PagesAndBlocksDown()
        {
            RockMigrationHelper.UpdatePageParent( SystemGuid.Page.STREAK_TYPES, SystemGuid.Page.REPORTING );
            RockMigrationHelper.UpdatePageParent( SystemGuid.Page.STEP_PROGRAMS, SystemGuid.Page.MANAGE );
            RockMigrationHelper.DeletePage( SystemGuid.Page.ENGAGEMENT ); //  Page: Engagement, Layout: Full Width, Site: Rock RMS
        }

        private void JobUp()
        {
            Sql( $@"
                UPDATE ServiceJob 
                SET
                    Name = 'Rebuild Streak Data',
                    Description = 'Rebuild streak maps. This runs on demand and has the cron expression set to the distant future since it does not run on a schedule.',
                    Class = 'Rock.Jobs.RebuildStreakMaps'
                WHERE
                    Guid = '{Rock.SystemGuid.ServiceJob.REBUILD_STREAK}';" );
        }

        private void JobDown()
        {
            // Intentionally blank
            // The name of sequences changed to streaks in the code. This migration fixes the class name of the job. Changing it back
            // to sequences will break since the code class name is the Streaks name.
        }
    }
}
