<?php declare(strict_types=1);

namespace DoctrineMigrations;

use Doctrine\DBAL\Migrations\AbstractMigration;
use Doctrine\DBAL\Schema\Schema;

/**
 * Auto-generated Migration: Please modify to your needs!
 */
final class Version20180512142700 extends AbstractMigration
{
    public function up(Schema $schema) : void
    {
        // this up() migration is auto-generated, please modify it to your needs
        $this->abortIf($this->connection->getDatabasePlatform()->getName() !== 'mysql', 'Migration can only be executed safely on \'mysql\'.');

        $this->addSql('ALTER TABLE user CHANGE description description LONGTEXT DEFAULT NULL, CHANGE delete_by_id delete_by_id INT DEFAULT NULL, CHANGE delete_by delete_by INT DEFAULT NULL, CHANGE delete_data delete_data DATETIME DEFAULT NULL, CHANGE update_by_id update_by_id INT DEFAULT NULL, CHANGE update_by update_by INT DEFAULT NULL, CHANGE update_date update_date DATETIME DEFAULT NULL, CHANGE banned_by_id banned_by_id INT DEFAULT NULL, CHANGE banned_by banned_by INT DEFAULT NULL, CHANGE banned_date banned_date DATETIME DEFAULT NULL, CHANGE banned_for banned_for INT DEFAULT NULL, CHANGE is_active is_active TINYINT(1) DEFAULT NULL');
    }

    public function down(Schema $schema) : void
    {
        // this down() migration is auto-generated, please modify it to your needs
        $this->abortIf($this->connection->getDatabasePlatform()->getName() !== 'mysql', 'Migration can only be executed safely on \'mysql\'.');

        $this->addSql('ALTER TABLE user CHANGE description description LONGTEXT NOT NULL COLLATE utf8mb4_unicode_ci, CHANGE delete_by_id delete_by_id INT NOT NULL, CHANGE delete_by delete_by INT NOT NULL, CHANGE delete_data delete_data DATETIME NOT NULL, CHANGE update_by_id update_by_id INT NOT NULL, CHANGE update_by update_by INT NOT NULL, CHANGE update_date update_date DATETIME NOT NULL, CHANGE banned_by_id banned_by_id INT NOT NULL, CHANGE banned_by banned_by INT NOT NULL, CHANGE banned_date banned_date DATETIME NOT NULL, CHANGE is_active is_active TINYINT(1) NOT NULL, CHANGE banned_for banned_for INT NOT NULL');
    }
}
