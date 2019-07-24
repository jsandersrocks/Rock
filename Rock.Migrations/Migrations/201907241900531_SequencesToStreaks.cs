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
            RenameTable(name: "dbo.SequenceOccurrenceExclusion", newName: "StreakTypeExclusion");
            RenameTable(name: "dbo.Sequence", newName: "StreakType");
            RenameTable(name: "dbo.SequenceEnrollment", newName: "Streak");
            RenameColumn(table: "dbo.Streak", name: "SequenceId", newName: "StreakTypeId");
            RenameColumn(table: "dbo.StreakTypeExclusion", name: "SequenceId", newName: "StreakTypeId");
            RenameIndex(table: "dbo.Streak", name: "IX_SequenceId", newName: "IX_StreakTypeId");
            RenameIndex(table: "dbo.Streak", name: "IX_SequenceId_PersonAliasId", newName: "IX_StreakTypeId_PersonAliasId");
            RenameIndex(table: "dbo.StreakTypeExclusion", name: "IX_SequenceId", newName: "IX_StreakTypeId");
            AddColumn("dbo.Streak", "InactiveDateTime", c => c.DateTime());
            AddColumn("dbo.Streak", "ExclusionMap", c => c.Binary());
        }
        
        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.Streak", "ExclusionMap");
            DropColumn("dbo.Streak", "InactiveDateTime");
            RenameIndex(table: "dbo.StreakTypeExclusion", name: "IX_StreakTypeId", newName: "IX_SequenceId");
            RenameIndex(table: "dbo.Streak", name: "IX_StreakTypeId_PersonAliasId", newName: "IX_SequenceId_PersonAliasId");
            RenameIndex(table: "dbo.Streak", name: "IX_StreakTypeId", newName: "IX_SequenceId");
            RenameColumn(table: "dbo.StreakTypeExclusion", name: "StreakTypeId", newName: "SequenceId");
            RenameColumn(table: "dbo.Streak", name: "StreakTypeId", newName: "SequenceId");
            RenameTable(name: "dbo.Streak", newName: "SequenceEnrollment");
            RenameTable(name: "dbo.StreakType", newName: "Sequence");
            RenameTable(name: "dbo.StreakTypeExclusion", newName: "SequenceOccurrenceExclusion");
        }
    }
}
